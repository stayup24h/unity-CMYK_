using UnityEngine;

public class LoginManager : MonoBehaviour
{
    public void StartGoogleLogin() {
        TheBackend.ToolKit.GoogleLogin.Android.GoogleLogin(true, GoogleLoginCallback);
    }

    private void GoogleLoginCallback(bool isSuccess, string errorMessage, string token) {
        if (isSuccess == false) {
            Debug.LogError(errorMessage);
            return;
        }
    
        Debug.Log("구글 토큰 : " + token);
        var bro = Backend.BMember.AuthorizeFederation(token, FederationType.Google);
        Debug.Log("페데레이션 로그인 결과 : " + bro);
    }

    public void SignOutGoogleLogin() {
        TheBackend.ToolKit.GoogleLogin.Android.GoogleSignOut(GoogleSignOutCallback);
    }

    private void GoogleSignOutCallback(bool isSuccess, string error) {
        if (isSuccess == false) {
            Debug.Log("구글 로그아웃 에러 응답 발생 : " + error);   
        } else {
            Debug.Log("로그아웃 성공");
    }
}
}
