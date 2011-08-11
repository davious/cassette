﻿using System;
using System.Text.RegularExpressions;
using System.Web;
using Should;
using Xunit;

namespace Cassette.UI
{
    public class PlaceholderTracker_Tests
    {
        [Fact]
        public void WhenInsertPlaceholder_ThenPlaceholderIdHtmlReturned()
        {
            var tracker = new PlaceholderTracker();
            var result = tracker.InsertPlaceholder(new HtmlString(""));

            var guidRegex = new Regex(@"[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}");
            var output = result.ToHtmlString();
            guidRegex.IsMatch(output).ShouldBeTrue();
        }

        [Fact]
        public void GivenInsertPlaceholder_WhenReplacePlaceholders_ThenHtmlInserted()
        {
            var tracker = new PlaceholderTracker();
            var html = tracker.InsertPlaceholder(new HtmlString("<p>test</p>"));

            tracker.ReplacePlaceholders(html.ToHtmlString()).ShouldEqual(
                Environment.NewLine + "<p>test</p>" + Environment.NewLine
            );
        }
    }
}
