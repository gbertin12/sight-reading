using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    private MethodTest mt;
    public void OneHandedScene()
    {
        NoteSpawner.notes.Clear();
        SceneManager.LoadScene(1);
    }
    public void TwoHandsScene()
    {
        NoteSpawner.notes.Clear();

        SceneManager.LoadScene(3);
    }
    public void SolfaReadSceneOH()
    {
        NoteSpawner.notes.Clear();
        NoteSpawnerOneHand.notes.Clear();
        SceneManager.LoadScene(4);
    }
    public void Games()
    {
        NoteSpawner.notes.Clear();

        SceneManager.LoadScene(0);
    }
    public void Settings()
    {
        SceneManager.LoadScene(2);
    }

    public void Return(int numScene)
    {
        NoteSpawner.notes.Clear();

        SceneManager.LoadScene(numScene);
    }

    public void TwoHandsGame()
    {
        NoteSpawner.notes.Clear();
        NoteSpawnerTwoHand.notes.Clear();
        NoteSpawnerOneHand.notes.Clear();
        SceneManager.LoadScene(6);
    }

    public void Shop()
    {
        SceneManager.LoadScene(7);
    }

    public void PartitionGame()
    {
        SceneManager.LoadScene(12);
    }
    public void PartitionSettings()
    {
        SceneManager.LoadScene(11);
    }
}
