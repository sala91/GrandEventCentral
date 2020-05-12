﻿using System.Collections.Generic;

namespace GrandEventCentral.Shared.ViewModels
{
    public class MenuItem
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public List<MenuItem> Items { get; set; }
    }
}
