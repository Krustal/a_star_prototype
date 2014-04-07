using UnityEngine;
using System.Collections;

// Stores properties and behavior global to the game. Properties such as camera pan
// height of the camera off the ground, width of buttons, etc.
// Provides easy access to global variables and lets all parts of the game access them
// e.g. current map name.
namespace Prototype {

	public static class ResourceManager {
		public static float ScrollSpeed { get { return 25; } }
		public static float RotateSpeed { get { return 100; } }
		public static int ScrollWidth { get { return 15; } }
		public static float MinCameraHeight { get { return 10; } }
		public static float MaxCameraHeight { get { return 40; } }
	}
}
