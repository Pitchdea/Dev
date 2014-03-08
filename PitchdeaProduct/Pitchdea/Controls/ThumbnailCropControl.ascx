<%@ Control Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="ThumbnailCropControl.ascx.cs" 
    ClassName="ThumbnailCropControl"
    Inherits="Pitchdea.Controls.ThumbnailCropControl" %>

<script src="js/jquery.Jcrop.js" type="text/javascript"></script> 
<link href="css/jquery.Jcrop.css" type="text/css" rel="stylesheet" />

<script  type="text/javascript">

    function linkUp(unusedIndex, container) {
        container = $(container); //We were passed a DOM reference, convert it to a jquery object

        //The code will look for a img.image, a div.preview, a.result, an input.result inside the specified container, and link them together.
        //Only 'img.image' is required, however.  
        
        //Find the original image
        var image = container.find("img.image");
        
        //jCrop will enforce this ratio:
        var forcedRatio = 250/160;

        //Find the URL of the original image minus the querystring.
        var path = image.attr('src');
        if (path.indexOf('?') > 0) path = path.substr(0, path.indexOf('?'));
        if (path.indexOf(';') > 0) path = path.substr(0, path.indexOf(';')); //For parsing Amazon-cloudfront compatible querystrings

        var cloudFront = image.attr('src').indexOf(';') > -1; //To use CloudFront-friendly URLs.

        //Find the preview div(s) (if they exist) and make sure the have a set height and width.
        var divPreview = container.find("div.preview");

        var previewMaxWidth = 250;
        var previewMaxHeight = 160;

        //Set the values explicitly.
        divPreview.css({
            width: previewMaxWidth + 'px',
            height: previewMaxHeight + 'px',
            overflow: 'hidden'
        });

        //Create another child div and style it to form a 'clipping rectangle' for the preview div.
        var innerPreview = $('<div />').css({
            overflow: 'hidden'
        }).addClass('innerPreview').appendTo(divPreview);

        //Create a copy of the image inside the inner preview div(s)
        $('<img />').attr('src', image.attr('src')).appendTo(innerPreview);

        //Find any links (if they exist)
        var links = container.find('a.result');
        //And any input fields (for postbacks, if desired)
        var inputs = container.find('input.result');


        //Create a function to update the link, hidden input, and preview pane
        var update = function(coords) {
            if (parseInt(coords.w) <= 0 || parseInt(coords.h) <= 0) return; //Require valid width and height

            var innerWidth = previewMaxWidth;
            var innerHeight = previewMaxHeight;

            innerPreview.css({
                width: Math.ceil(innerWidth) + 'px',
                height: Math.ceil(innerHeight) + 'px',
                marginTop: (previewMaxHeight - innerHeight) / 2 + 'px',
                marginLeft: (previewMaxWidth - innerWidth) / 2 + 'px',
                overflow: 'hidden'
            });
            //Set the outer div's padding so it stays centered
            divPreview.css({

            });

            //Calculate how much we are shrinking the image inside the preview window
            var scalex = innerWidth / coords.w;
            var scaley = innerHeight / coords.h;

            //Set the width and height of the image so the right areas appear at the right scale appear.
            innerPreview.find('img').css({
                width: Math.round(scalex * image.width()) + 'px',
                height: Math.round(scaley * image.height()) + 'px',
                marginLeft: '-' + Math.round(scalex * coords.x) + 'px',
                marginTop: '-' + Math.round(scaley * coords.y) + 'px'
            });

            //Calculate the querystring
            var query = '?';

            //Add final size, if specified.
            var inputWidth = container.find('input.width');
            var inputHeight = container.find('input.height');
            if (inputWidth.size() > 0 && parseInt(inputWidth.val()) > 1) query += 'maxwidth=' + inputWidth.val() + '&';
            if (inputHeight.size() > 0 && parseInt(inputHeight.val()) > 1) query += 'maxheight=' + inputHeight.val() + '&';

            //Add crop rectangle
            query += 'crop=(' + coords.x + ',' + coords.y + ',' + coords.x2 + ',' + coords.y2 + ')&cropxunits=' + image.width() + '&cropyunits=' + image.height();
            //Replace ? and & with ; if using Amazon Cloudfront
            if (cloudFront) query = query.replace(/\?\&/g, ';');

            //Now, update the links and input values.
            links.attr('href', path + query);
            inputs.attr('value', path + query);
        };

        //Start up jCrop
        var jcropReference = $.Jcrop(image);
        jcropReference.setOptions({
            onChange: update,
            onSelect: update,
            aspectRatio: forcedRatio,
            bgColor: 'black',
            bgOpacity: 0.6
        });

        //Call the function to init the preview windows
        update({ x: 0, y: 0, x2: image.width(), y2: image.height(), w: image.width(), h: image.height() });
    }

    // Remember to invoke within jQuery(window).load(...)
    // If you don't, Jcrop may not initialize properly
    jQuery(window).load(function () {
        $('.image-cropper').each(linkUp);
    });


</script>
<style type="text/css">
.jcropper-holder { border: 1px black solid; }

</style> 

HAI THERE!

<br/>
<br/>
<div class="image-cropper">
    <asp:Image runat="server" ID="uploadedImage" CssClass="image"/>
    <div class="preview" style="margin-left:100px;"></div>
    <a class="result">View the result</a>
</div>