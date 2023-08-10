using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip CollectFX;
    [SerializeField]
    private AudioClip DroppedFX;

    private AudioSource m_AudioSource;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        string _thisTrashTag = this.gameObject.tag;
        string _enteredTrashItemTag = other.gameObject.tag;

        if (_thisTrashTag == _enteredTrashItemTag)
        {
            m_AudioSource.clip = CollectFX;
            Destroy(other.gameObject);
        }
        else
        {
            m_AudioSource.clip = DroppedFX;
        }

        m_AudioSource.Play();
    }
}
