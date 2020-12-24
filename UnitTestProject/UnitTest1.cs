using ApprovalTests;
using ApprovalTests.Reporters;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using Avalonia.UnitTests;
using NUnit.Framework;
using System;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using UnitTestProject.Utils;

namespace UnitTestProject
{
    [UseReporter(typeof(DiffReporter))]
    public class UnitTest1
    {
        static UnitTest1()
        {
            var fwNm = Util.GetRuntimeName();
            Approvals.RegisterDefaultNamerCreation(() => new ChangeOutputPathNamer("Out"));
        }

        string assetPath;

        public UnitTest1()
        {
            var asm = Assembly.GetExecutingAssembly();
            assetPath = Path.GetDirectoryName(asm.Location);
        }

        [Test]
        public void Transform_givenTest1_generatesExpectedResult()
        {
            using (UnitTestApplication.Start(TestServices.StyledWindow))
            {
                var text = Util.LoadText("Test1.md");
                var markdown = new Markdown.Avalonia.Markdown();
                var result = markdown.Transform(text);
                Approvals.Verify(Util.AsXaml(result));
            }
        }

        [Test]
        public void Transform_givenLists1_generatesExpectedResult()
        {
            using (UnitTestApplication.Start(TestServices.StyledWindow))
            {
                var text = Util.LoadText("Lists1.md");
                var markdown = new Markdown.Avalonia.Markdown();
                var result = markdown.Transform(text);
                Approvals.Verify(Util.AsXaml(result));
            }
        }

        [Test]
        public void Transform_givenLists2_generatesExpectedResult()
        {
            using (UnitTestApplication.Start(TestServices.StyledWindow))
            {
                var text = Util.LoadText("Lists2.md");
                var markdown = new Markdown.Avalonia.Markdown();
                var result = markdown.Transform(text);
                Approvals.Verify(Util.AsXaml(result));
            }
        }

        [Test]
        public void Transform_givenLists3_generatesExpectedResult()
        {
            using (UnitTestApplication.Start(TestServices.StyledWindow))
            {
                var text = Util.LoadText("Lists3.md");
                var markdown = new Markdown.Avalonia.Markdown();
                var result = markdown.Transform(text);
                Approvals.Verify(Util.AsXaml(result));
            }
        }

        [Test]
        public void Transform_givenTables1_generatesExpectedResult()
        {
            using (UnitTestApplication.Start(TestServices.StyledWindow))
            {
                var text = Util.LoadText("Tables.md");
                var markdown = new Markdown.Avalonia.Markdown();
                var result = markdown.Transform(text);
                Approvals.Verify(Util.AsXaml(result));
            }
        }

        [Test]
        public void Transform_givenHorizontalRules_generatesExpectedResult()
        {
            using (UnitTestApplication.Start(TestServices.StyledWindow))
            {
                var text = Util.LoadText("HorizontalRules.md");
                var markdown = new Markdown.Avalonia.Markdown();
                var result = markdown.Transform(text);
                Approvals.Verify(Util.AsXaml(result));
            }
        }

        [Test]
        public void Transform_givenLinksInline_generatesExpectedResult()
        {
            using (UnitTestApplication.Start(TestServices.StyledWindow))
            {
                var text = Util.LoadText("Links_inline_style.md");
                var markdown = new Markdown.Avalonia.Markdown();
                markdown.DisabledTootip = true;
                var result = markdown.Transform(text);
                Approvals.Verify(Util.AsXaml(result));
            }
        }

        [Test]
        public void Transform_givenTextStyles_generatesExpectedResult()
        {
            using (UnitTestApplication.Start(TestServices.StyledWindow))
            {
                var text = Util.LoadText("Text_style.md");
                var markdown = new Markdown.Avalonia.Markdown();
                var result = markdown.Transform(text);
                Approvals.Verify(Util.AsXaml(result));
            }
        }

        [Test]
        public void Transform_givenImages_generatesExpectedResult()
        {
            using (UnitTestApplication.Start(TestServices.StyledWindow))
            {
                var text = Util.LoadText("Images.md");
                var markdown = new Markdown.Avalonia.Markdown();
                markdown.AssetPathRoot = assetPath;

                var result = markdown.Transform(text);
                Approvals.Verify(Util.AsXaml(result));
            }
        }

        [Test]
        public void Transform_givenBlockqoute_generatesExpectedResult()
        {
            using (UnitTestApplication.Start(TestServices.StyledWindow))
            {
                var text = Util.LoadText("Blockquite.md");
                var markdown = new Markdown.Avalonia.Markdown();

                var result = markdown.Transform(text);
                Approvals.Verify(Util.AsXaml(result));
            }
        }

        [Test]
        public void Transform_givenMixing_generatesExpectedResult()
        {
            using (UnitTestApplication.Start(TestServices.StyledWindow))
            {
                var text = Util.LoadText("Mixing.md");
                var markdown = new Markdown.Avalonia.Markdown();
                markdown.AssetPathRoot = assetPath;

                var result = markdown.Transform(text);
                Approvals.Verify(Util.AsXaml(result));
            }
        }

        [Test]
        public void Transform_givenEmoji()
        {
            using (UnitTestApplication.Start(TestServices.StyledWindow))
            {
                var text = Util.LoadText("Emoji.md");
                var markdown = new Markdown.Avalonia.Markdown();
                markdown.AssetPathRoot = assetPath;

                var result = markdown.Transform(text);
                Approvals.Verify(Util.AsXaml(result));
            }
        }
    }

}