/*
This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software Foundation,
Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.

The Original Code is Copyright (C) 2020 Voxell Technologies and Contributors.
All rights reserved.
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using Voxell.Inspector;

namespace SmartAssistant.Core
{
  public class GameManager : MonoBehaviour
  {
    [Scene]
    public string[] initialScenes;

    private bool[] _sceneLoaded;

    void Awake()
    {
      // QualitySettings.vSyncCount = 1;
      // Application.targetFrameRate = 60;
    }

    [Button]
    void Start()
    {
      _sceneLoaded = new bool[initialScenes.Length];
      CheckLoadedScenes();
      LoadScenes();
    }

    void Update() {}

    private void CheckLoadedScenes()
    {
      if (SceneManager.sceneCount > 0)
      {
        for (int i=0; i < SceneManager.sceneCount; i++)
        {
          Scene scene = SceneManager.GetSceneAt(i);
          for (int s=0; s < initialScenes.Length; s++)
            if (scene.name == initialScenes[s]) _sceneLoaded[s] = true;
        }
      }
    }

    private void LoadScenes()
    {
      for (int s=0; s < initialScenes.Length; s++)
      {
        if (!_sceneLoaded[s])
        {
          SceneManager.LoadSceneAsync(initialScenes[s], LoadSceneMode.Additive);
          _sceneLoaded[s] = true;
        }
      }
    }
  }
}