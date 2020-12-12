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
        public void Transform_givenLists1_generatesExpectedResult()
        {
            using (UnitTestApplication.Start(TestServices.StyledWindow))
            {
                var text = Util.LoadText("Lists1.md");
                var markdown = new Markdown.Avalonia.Markdown();
                var result = markdown.Transform(text);

                var rowspc = result.GetValue(Avalonia.Controls.Grid.RowSpanProperty);


                Approvals.Verify(Util.AsXaml(result));
            }
        }
    }
}
