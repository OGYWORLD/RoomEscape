using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

#region 오가을
#endregion

/// <summary>
/// 오브젝트 Hover 됐을 때 Outline 활성화 시키는 스크립트 입니다.
/// 셰이더 그래프의 m_HighlightActive 속성 값을 변경하여 사용합니다.
/// 해당 기능을 사용하기 위해서는 오브젝트에 GlassOutlineShader가 셰이더로 지정된
/// Material 컴포넌트가 부착되어야 합니다.
/// </summary>

public class CHightObj : MonoBehaviour
{
    [FormerlySerializedAs("renderer")]
    public Renderer Renderer;

    float m_Highlighted = 0.0f;
    MaterialPropertyBlock m_Block;
    int m_HighlightActiveID;

    private void Start()
    {
        if (Renderer == null)
        {
            Renderer = GetComponent<Renderer>();
        }

        m_HighlightActiveID = Shader.PropertyToID("HighlightActive");
        m_Block = new MaterialPropertyBlock();
        m_Block.SetFloat(m_HighlightActiveID, m_Highlighted);
        Renderer.SetPropertyBlock(m_Block);
    }

    public void Highlight()
    {
        m_Highlighted = 1.0f;

        Renderer.GetPropertyBlock(m_Block);
        m_Block.SetFloat(m_HighlightActiveID, m_Highlighted);
        Renderer.SetPropertyBlock(m_Block);
    }

    public void RemoveHighlight()
    {
        m_Highlighted = 0.0f;

        Renderer.GetPropertyBlock(m_Block);
        m_Block.SetFloat(m_HighlightActiveID, m_Highlighted);
        Renderer.SetPropertyBlock(m_Block);
    }
}
