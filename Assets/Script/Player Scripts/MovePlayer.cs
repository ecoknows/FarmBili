using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.EventSystems;

public class MovePlayer : MonoBehaviour
{
	

	float moveSpeed = 2f;

	Rigidbody2D rb;
	public GameObject indicator;
	public GameObject obj;

	 Animator anim;

	Touch touch;
	Vector3 touchPosition, whereToMove;
	bool isMoving = false;
	bool deym;


	float previousDistanceToTouchPos, currentDistanceToTouchPos;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		deym = false;

		InvokeRepeating("LoadSave", 0f,0f);
	}

	void Update()
	{
		//text.SetText(Input.touchCount.ToString());

		if (isMoving)
		{
			currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;
		}


		if (Input.touchCount > 0)
		{
			touch = Input.GetTouch(0);

			if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
			{
				if (touch.phase == TouchPhase.Began)
				{
					previousDistanceToTouchPos = 0;
					currentDistanceToTouchPos = 0;
					isMoving = true;
					touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
					touchPosition.z = 0;
					whereToMove = (touchPosition - transform.position).normalized;
					Destroy(obj);
					obj = Instantiate(indicator, new Vector2(touchPosition.x, touchPosition.y-2), Quaternion.identity) as GameObject;

					Vector2 vect = new Vector2(whereToMove.x * 5f, whereToMove.y * 5f);
					rb.velocity = vect * moveSpeed;

					float x = whereToMove.x;
					float y = whereToMove.y;
					if (deym)
					{
						anim.SetTrigger("end");
						deym = false;
					}
					if (x >= -0.5 && x <= 0.5 && y >= 0)
					{
						anim.SetTrigger("isBack");
						deym = true;
					}
					else if (x >= -0.5 && x <= 0.5 && y <= 0)
					{
						anim.SetTrigger("isFront");
						deym = true;
					}
					else if (y >= -1 && y <= 1 && x <= 0)
					{
						anim.SetTrigger("isLeft");
						deym = true;
					}
					else if (y >= -1 && y <= 1 && x >= 0)
					{
						anim.SetTrigger("isRight");
						deym = true;
					}
				}
			}

		}
		if ( (Math.Round(touchPosition.x) == Math.Round(transform.position.x) ||
			Math.Round(touchPosition.x)+1 == Math.Round(transform.position.x) ||
			Math.Round(touchPosition.x) == Math.Round(transform.position.x)+1 )
			&&
			( Math.Round(touchPosition.y) == Math.Round(transform.position.y) ||
			Math.Round(touchPosition.y)+1 == Math.Round(transform.position.y) ||
			Math.Round(touchPosition.y) == Math.Round(transform.position.y)+1)
			&&
			deym)
		{
			anim.SetTrigger("end");

			PlayerData playerPosition = new PlayerData(this);
			SaveLoad.Save<PlayerData>(playerPosition, "Player");

			deym = false;
			Destroy(obj);
		}

		if (currentDistanceToTouchPos > previousDistanceToTouchPos )
		{
			isMoving = false;
			rb.velocity = Vector2.zero;
		}

		if (isMoving)
		{
			previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;
		}


	}



	public void LoadSave()
	{
		if (SaveLoad.SaveExist("Player")){
			PlayerData playerData = SaveLoad.Load<PlayerData>("Player");
			Vector3 vec = new Vector3(playerData.position[0], playerData.position[1]);
			transform.position = vec;
		}
		PlayerNecessity.Instance.GetInventory().Load();
	}



}
