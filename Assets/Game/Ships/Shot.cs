﻿using UnityEngine;

namespace NeonChaser.Core
{
	[RequireComponent(typeof(Collider)), DisallowMultipleComponent]
	public class Shot : MonoBehaviour
	{
		public int damage;
		public float speed;

		public Transform Transform { get; private set; }

		void Awake()
		{
			this.Transform = GetComponent<Transform>();
		}

		void FixedUpdate()
		{
			var velocity = Vector3.forward * this.speed;
			var delta = velocity * Time.fixedDeltaTime;
			this.Transform.Translate(delta);
		}
	}
}
