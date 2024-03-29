﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ILinkFinderService<T>
    {
        IEnumerable<T> GetLinksFromHTML(string html);
        IEnumerable<T> GetLinksFromMarkdown(string markdown);
    }
}
