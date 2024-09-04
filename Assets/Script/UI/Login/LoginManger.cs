using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManger : MonoBehaviour
{
    [Header("Login")]
    public InputField Login_idInput;
    public InputField Login_numberInput;

    [Header("Sing_up")]
    public InputField Singup_idInput;
    public InputField Singup_numberInput;

    [Header("Button")]
    public GameObject LoginPanel;
    public GameObject SingupPanel;
    public GameObject MainPanel;

    public Text Login_errorText;
    public Text Singup_errorText;

    private Dictionary<string, string> Dic_userData = new Dictionary<string, string>();
    private const string UserListKey = "UserList";  // 유저 목록을 저장할 키

    private void Start()
    {
        LoadUserData();
    }

    
    public void SignUp()
    {

        string id = Singup_idInput.text;
        string number = Singup_numberInput.text;

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(number))
        {
            Singup_errorText.text = "아이디와 비밀번호를 입력해주세요.";
            return;
        }
        if (Dic_userData.ContainsKey(id))
        {
            Singup_errorText.text = "이미 존재하는 아이디입니다.";
            return;
        }

        Dic_userData.Add(id, number);
        Singup_errorText.text = "화원가입이 완료되었습니다.";
        SaveUserData(id, number);//데이터 저장 메서드
      
    }

    
    public void Login()
    {
      
        string id = Login_idInput.text;
        string number = Login_numberInput.text;

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(number))
        {
            Login_errorText.text = "아이디와 비밀번호를 입력해주세요.";
            return;
        }

        if (Dic_userData.TryGetValue(id, out string storesNumber))
        {
            if (number == storesNumber)
            {
                Login_errorText.text = "로그인 성공";
                UImanger.Instance.PlyerName(id);
                Invoke("GameStart", 0.5f);
               
            }
            else
            {
                Login_errorText.text = "잘못된 번호입니다";
            }

        }
        else
        {
            Login_errorText.text = "존재하지 않는 아이디입니다.";
        }
    }


    public void ShowLoginButtonClike()
    {
        Login();
    }

    public void ShowSignupButtonClike()
    {
        SignUp();
    }

    public void SignupTextButton()
    {
       SingupPanel.gameObject.SetActive(true);
       LoginPanel.gameObject.SetActive(false);
        
    }

    public void SigninTextButton()
    {
        SingupPanel.gameObject.SetActive(false);
        LoginPanel.gameObject.SetActive(true);
    }

    public void GameStart()
    {
        MainPanel.gameObject.SetActive(false);

    }

    private void SaveUserData(string id, string number)
    {
        PlayerPrefs.SetString(id, number);

        // 유저 목록 업데이트
        string userList = PlayerPrefs.GetString(UserListKey, "");
        if (!userList.Contains(id))
        {
            userList += id + ";";  // 아이디 목록에 추가
            PlayerPrefs.SetString(UserListKey, userList);
        }

        PlayerPrefs.Save();  // 데이터 저장
    }



    // 데이터를 불러오는 함수
    private void LoadUserData()
    {
        // 저장된 유저 목록을 불러옴
        string userList = PlayerPrefs.GetString(UserListKey, "");
        string[] users = userList.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        // 각 유저의 아이디와 비밀번호를 불러와서 Dic_userData에 저장
        foreach (string id in users)
        {
            if (PlayerPrefs.HasKey(id))
            {
                string number = PlayerPrefs.GetString(id);
                Dic_userData[id] = number;
            }
        }
    }
}
