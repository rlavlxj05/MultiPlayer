# MultiPlayer
 포트폴리오을 목적으로  제작된 프로젝트입니다. 모바일로 정해 유니티 NetCode를 기반으로 제작하여 멀티시스템을 구축하였습니다. 

### 멀티시스템을 구현한 영상입니다.

### https://www.youtube.com/watch?v=Rus1WR7ag_Y

[이동구현]

플레이어컨트롤러 : https://github.com/rlavlxj05/MultiPlayer/blob/main/Script/PlayerController.cs

조이스틱 : https://github.com/rlavlxj05/MultiPlayer/blob/main/Script/Joystick2.cs

이동같은 경우 UI에 조이스틱을 제작하여 스틱이 움직인 위치에 따라 x,y수치가 실시간으로 생성되게 했고 손을 때면 가운데로 원위치되도록 구현했습니다.

컴포넌트를 활용해서 플레이어스크립트에 조이스틱를 호출해서 플레이어에게 조이스틱 x,y 수치를 x=x, y=z로 주면서 플레이어가 3D로 움직이도록 했습니다.

[옷입히기]
https://github.com/rlavlxj05/MultiPlayer/blob/main/Script/CostumeObj.cs

처음에는 플레이어안에 코스튬을 넣고 활성화/비활성화를 하려고 했습니다. 하지만 유니티네트워크에서는 비활성화 되있는 오브젝트는 활성화를 못하게 되있었습니다. 그래서 버튼클릭 시 프리펩을 생성하고 프리펩이 플레이어를 따라다니도록했습니다. 그 결과 멀티접속을 했을 때 오류없이 옷을 입힐 수 있었습니다. 

[카메라]

https://github.com/rlavlxj05/MultiPlayer/blob/main/Script/UI/CameraFollow.cs

따라다닐 타켓의 Transform과 자신만의 Transform을 지정하여 플레이어가 움직였을 때 카메라는 고정되어 따라다닐 수 있었습니다.

[오류해결]

https://github.com/rlavlxj05/MultiPlayer/blob/main/Script/LocalManager.cs

카메라, 조이스틱, UI 등 개인이 가져야하는 것들이 호스트만 적용되고 클라이언트는 적용이 안되는 오류가 있었습니다. 하지만 로컬매니저를 만들어 로컬 플레이어의 구성 요소가 활성화 되도록했습니다. 그 결과 멀티 시 오류가 없었습니다.
