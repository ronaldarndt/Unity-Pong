using UnityEngine;

namespace Extensions
{
    public static class CameraHelper
    {
        public static Vector2 Center => Camera.main.ScreenToWorldPoint( 
            new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
    }
}
