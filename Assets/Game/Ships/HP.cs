﻿using UnityEngine;

namespace NeonChaser.Core
{
	public class HP : MonoBehaviour
	{

		public delegate void DeadEventHandler(GameObject deadObject);
		public event DeadEventHandler DeadEvent;

		public int value
		{
			get;
			private set;
		}

		#pragma warning disable CS0649
		[SerializeField]
		private int max;
		#pragma warning restore CS0649

		void Awake()
		{
			this.value = this.max;
		}

		public void Decrease(int amount)
		{
			Set(this.value - amount);
		}

		public void Increase(int amount)
		{
			Set(this.value + amount);
		}

		public void Set(int value)
		{
			if (value > this.max)
				value = this.max;
			this.value = value;
			if (this.value <= 0)
				Death();
		}

		void Death()
		{
			this.DeadEvent?.Invoke(this.gameObject);
		}
	}
}
