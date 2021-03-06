# 네이버, 카카오 주소 -> GPS 좌표 조회 



## 개요

1. 네이버 클라우드 ( ncloud.com) 
2. 카카오 Developers ( developers.kakao.com) 



-  위의 2가지 사이트에서 제공하는 API를 이용하여 주소를 입력하면 해당 GPS 좌표값을 돌려주기 위한 API 서버를 구성하는 샘플 프로젝트. 
- C# .net core 의 Web API 프로젝트를 이용하여 구성.
- 간단한 구조의 nLog 추가하여 로깅 작업이 가능하도록 구성
- 이용 라이브러리 : nlog (로깅), restSharp (http통신)



## 호스팅

- C# .net core를 가지고 호스팅하는 방법은 일반적으로 3가지가 있음. 
  - 기존 window의 웹서버 호스팅 할 때 사용하는 것과 유사하게 IIS 를 이용하는 방법
  - Docker를 이용하는 방법
  - 윈도우 서비스에 올리는 방법 
- 그 중 IIS를 이용하는 방법으로 올릴 수 있도록  작성된 코드임. 이외의 다른 방법으로 호스팅을 하기 위해서는 추가적인 코드 작성 및 설정이 필요함. 
- 물론 net core 로 올리는 경우에는 기존의 IIS와 그냥은 호환이 되지 않기 때문에 .net core hosting bundle를 설치해주고, IIS 를 껐다 켜주는 작업이 필요함. 

   => 코드 작성 시간보다 호스팅하는 방법을 알아내고 처리하는데 필요한 시간이 더 많았음.

- 추후에 관련 포스팅을 작성할 예정