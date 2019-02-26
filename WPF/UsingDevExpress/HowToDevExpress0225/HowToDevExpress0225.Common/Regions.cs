using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToDevExpress0225.Common
{
    public  static class Regions
    {
        //모듈 시험을 위한 Region
        public static string MainWindow { get { return "MainWindow"; } }
        public static string CLMView { get { return "CLMView"; } }
        public static string SAMView { get { return "SAMView"; } }
        //여기부터 진짜 Region
        public static string RibbonArea { get { return "RibbonArea"; } } //상단 메뉴 지역
        public static string TreeArea { get { return "TreeArea"; } }//좌측 트리 지역
        public static string TopReportArea { get { return "TopReportArea"; } }//우측 상단 report
        public static string BottomReportArea { get { return "BottomReportArea"; } }//우측 상단 report
    }
}
