﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pitchdea
{
    public partial class ViewIdeaPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ideaTitle = "Your Idea";
            Title = ideaTitle+ " | Pitchdea";
        }
    }
}