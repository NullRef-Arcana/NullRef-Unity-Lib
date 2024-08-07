﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// compile with: -doc:DocFileName.xml 
namespace NullrefLib.Unity {
	public static class CustomUnityExtensions {
		public static bool ContainsLayer(this LayerMask mask, int layer) {
			return mask == (mask | (1 << layer));
		}

		public static List<Transform> GetAllChildrenList(this Transform transform) {
			List<Transform> children = new List<Transform>();
			int c = transform.childCount;
			for (int i = 0; i < c; i++)
			{
				Transform child = transform.GetChild(i);
				if (child != null)
					children.Add(child);
			}
			return children;
		}

		public static Transform[] GetAllChildrenArray(this Transform transform) {
			int c = transform.childCount;
			Transform[] children = new Transform[c];
			for (int i = 0; i < c; i++)
			{
				children[i] = transform.GetChild(i);
			}

			return children;
		}

		public static IEnumerable<Transform> GetAllChildrenEnumerable(this Transform transform) {
			int c = transform.childCount;
			IEnumerable<Transform> col = Enumerable.Empty<Transform>();
			for (int i = 0; i < c; i++)
			{
				Transform child = transform.GetChild(i);
				if (child != null)
				{
					col.Append(child);
				}
			}
			return col;
		}

		/// <summary>
		/// Returns a vector from the element calling the method to the parameter target.
		/// </summary>
		/// <returns></returns>
		public static Vector3 RelativePosTo(this Component origin, Component target) {
			return target.transform.position - origin.transform.position;
		}

		/// <summary>
		/// Returns a vector from the element calling the method to the parameter target.
		/// </summary>
		public static Vector3 RelativePosTo(this Component origin, Vector3 target) {
			return target - origin.transform.position;
		}

		public static Vector2 RotateTowards2D(this Vector2 source, Vector2 target, float maxAngle = 180) {
			float deltaAngle = Vector2.SignedAngle(source, target);
			deltaAngle = Mathf.Abs(deltaAngle) > maxAngle ? maxAngle * Mathf.Sign(deltaAngle) : deltaAngle;
			return Quaternion.Euler(0, 0, deltaAngle) * source;
		}

		public static Vector3 FlipYZ(this Vector3 vector) {
			(vector.y, vector.z) = (vector.z, vector.y);
			return vector;
		}

		/// <summary>
		/// Converts a vector3 to a Vector2 using x and z values instead of x and y.
		/// </summary>
		public static Vector2 ToVector2Z(this Vector3 vector) {
			return new Vector2(vector.x, vector.z);
		}

		/// <summary>
		/// Returns the vector with its x value set to 0.
		/// </summary>
		public static Vector3 ZeroX(this Vector3 vector) {
			vector.x = 0;
			return vector;
		}

		/// <summary>
		/// Returns the vector with its y value set to 0.
		/// </summary>
		public static Vector3 ZeroY(this Vector3 vector) {
			vector.y = 0f;
			return vector;
		}

		/// <summary>
		/// Returns the vector with its z value set to 0.
		/// </summary>
		public static Vector3 ZeroZ(this Vector3 vector) {
			vector.z = 0f;
			return vector;
		}

		/// <summary>
		/// Returns the vector with its x value set to 1.
		/// </summary>
		public static Vector3 OneX(this Vector3 vector) {
			vector.x = 1f;
			return vector;
		}

		/// <summary>
		/// Returns the vector with its y value set to 1.
		/// </summary>
		public static Vector3 OneY(this Vector3 vector) {
			vector.y = 1f;
			return vector;
		}

		/// <summary>
		/// Returns the vector with its z value set to 1.
		/// </summary>
		public static Vector3 OneZ(this Vector3 vector) {
			vector.z = 1f;
			return vector;
		}

		public static Rect ScaleCentered(this Rect rect, float scalar) {
			Vector2 center = rect.center;
			rect.size = new Vector2(rect.width * scalar, rect.height * scalar);
			rect.center = center;
			return rect;
		}

		public static T IntermediaryPrint<T>(this T item, string message) {
			Debug.Log(message);
			return item;
		}

		public static T IntermediaryPrint<T>(this T item) {
			Debug.Log(item);
			return item;
		}
	}
}
