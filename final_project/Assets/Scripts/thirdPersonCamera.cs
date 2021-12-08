using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class thirdPersonCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private CinemachineFreeLook _cinemachineFreeLook;
    private string _inputAxisNameX;
    private string _inputAxisNameY;
    public bool fade;
    public GameObject deathMenu;
    
    private void Start()
    {
        fade = false;
    }
    void Awake()
    {
        _cinemachineFreeLook = GetComponent<CinemachineFreeLook>();
        _inputAxisNameX = _cinemachineFreeLook.m_XAxis.m_InputAxisName;
        _inputAxisNameY = _cinemachineFreeLook.m_YAxis.m_InputAxisName;
    }

    void Update()
    {
        _cinemachineFreeLook.m_XAxis.m_InputAxisName = Input.GetMouseButton(1) ? _inputAxisNameX : "";
        _cinemachineFreeLook.m_YAxis.m_InputAxisName = Input.GetMouseButton(1) ? _inputAxisNameY : "";

        _cinemachineFreeLook.m_Orbits[0].m_Radius = _cinemachineFreeLook.m_Orbits[0].m_Radius + Input.mouseScrollDelta.y * -1f;
        _cinemachineFreeLook.m_Orbits[1].m_Radius = _cinemachineFreeLook.m_Orbits[1].m_Radius + Input.mouseScrollDelta.y * -1f;
        _cinemachineFreeLook.m_Orbits[2].m_Radius = _cinemachineFreeLook.m_Orbits[2].m_Radius + Input.mouseScrollDelta.y * -1f;




        if(fade)
        {
            GetComponent<CinemachineStoryboard>().m_Alpha += 1f * Time.deltaTime;

            if(GetComponent<CinemachineStoryboard>().m_Alpha >1)
            {
                deathMenu.SetActive(true);
            }

        }
    }
}
