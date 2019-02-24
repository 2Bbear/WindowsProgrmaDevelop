using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
namespace Prism_LocalizationExample
{
    /*
     작성일    : 20190223
     작성자    : JJH
     목적      : Localization을 한국어로 쉽게하기 위하여 한국어를 이용한 Localization의 일련의 과정을 메소드를 통해 지원한다.
                해당 클래스로 일정한 한국어를 넣으면 일정한 영문형 ID를 반환하는 형식의 Class이다.
     형태     : singletone. 형태로 어디서든 사용 가능하다.
         */
    public class Ko_KR_localization
    {
        #region 싱글톤을 사용한 생성자
        private static Ko_KR_localization instance=null;
        private Ko_KR_localization()
        {
          
        }
        public static Ko_KR_localization getInstance()
        {
            if(instance==null)
            {
                instance = new Ko_KR_localization();
            }
            return instance;
        }
        #endregion

        #region 멤버변수
        String resourcePath; // 리소스 위치가 저장되는 변수
        public string ResourcePath { get => resourcePath; set => resourcePath = value; }
      


        #endregion

        #region 멤버함수
        //한글을 넣어서 ID값 받아오기
        public String getIDCode(String arg)
        {
            String result = "";
           
            switch (arg)
            {
                case "확인":
                    {

                        break;
                    }
                case "취소":
                    {
                        break;
                    }
            }
            return result;
        }

        //Resources 파일에 데이터 추가하기
        private Boolean addResourceData()
        {
            Boolean result = false;



            return result;
        }
        //Resources 파일에 데이터 삭제하기
        private Boolean deleteResourceData()
        {
            bool result = false;
            return result;
        }
        //Resources 파일에 데이터 수정하기
        private Boolean modifyResourceData()
        {
            bool result = false;
            return result;
        }
        #endregion


        #region 리소스파일 접근용
        

        #endregion







    }
    /*
     System.Windows.form dll이 필요하니 참조추가하세요

    1. xaml에서 클래스 함수 불러와서 사용하는 방법 찾아야함
    2. 받은 한글로 resource텍스트 파일에 형식에 맞춰서 작성 후 저장
    3.  

     */
}
