using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackupCameraProjectionChange : MonoBehaviour {

	/// <summary>
	/// 相机透视改变是否触发(调用只需把此值改为true)
	/// </summary>
	public bool ChangeProjection = false; 
	private bool _changing = false;
	public float ProjectionChangeTime = 0.5f;
	private float _currentT = 0.0f;

	void Start(){
		StartCoroutine (waitSeconds ());

	}

	IEnumerator waitSeconds(){
		yield return new WaitForSeconds (0.75f);
		ChangeProjection = true;
	}

	private void Update()
	{///检测，避免变换过程中发生混乱
		if(_changing)
		{
			ChangeProjection = false;
		}
		else if(ChangeProjection)
		{
			_changing = true;
			_currentT = 0.0f;
		}
	}
	/// <summary>
	/// Unity3D中Update和Lateupdate的区别。Lateupdate和Update每一祯都被执行，但是执行顺序不一样，先执行Updatee然后执行lateUpdate。
	///如果你有两个脚本JS1、JS2，两个脚本中都有Update()函数, 在JS1中有 lateUpdate ,JS2中没有。那么 lateUpdate 函数会等待JS1、JS2两个脚本的Update()函数 都执行完后才执行。
	/// </summary>
	private void LateUpdate()
	{
		if(!_changing)
		{
			return;
		}
		//将当前的 是否正视图值 赋值给currentlyOrthographic变量
		bool currentlyOrthographic = Camera.main.orthographic;
		//定义变量存放当前摄像机的透视和正视矩阵信息；
		Matrix4x4 orthoMat, persMat;
		if(currentlyOrthographic)//如果当前摄像机为正视状态
		{
			orthoMat = Camera.main.projectionMatrix;

			Camera.main.orthographic = false;
			Camera.main.ResetProjectionMatrix();
			persMat = Camera.main.projectionMatrix;
		} else//否则当前摄像机为透视状态
		{
			persMat = Camera.main.projectionMatrix;

			Camera.main.orthographic = true;
			Camera.main.ResetProjectionMatrix();
			orthoMat = Camera.main.projectionMatrix;
		}
		Camera.main.orthographic = currentlyOrthographic;

		_currentT += (Time.deltaTime / ProjectionChangeTime);
		if(_currentT < 1.0f)
		{
			if(currentlyOrthographic)
			{
				Camera.main.projectionMatrix = MatrixLerp(orthoMat, persMat, _currentT * _currentT);
			}
			else
			{
				Camera.main.projectionMatrix = MatrixLerp(persMat, orthoMat, Mathf.Sqrt(_currentT));
			}
		}
		else
		{
			_changing = false;
			Camera.main.orthographic = !currentlyOrthographic;
			Camera.main.ResetProjectionMatrix();
		}
	}

	private Matrix4x4 MatrixLerp(Matrix4x4 from, Matrix4x4 to, float t)
	{
		t = Mathf.Clamp(t, 0.0f, 1.0f);
		Matrix4x4 newMatrix = new Matrix4x4();
		newMatrix.SetRow(0, Vector4.Lerp(from.GetRow(0), to.GetRow(0), t));
		newMatrix.SetRow(1, Vector4.Lerp(from.GetRow(1), to.GetRow(1), t));
		newMatrix.SetRow(2, Vector4.Lerp(from.GetRow(2), to.GetRow(2), t));
		newMatrix.SetRow(3, Vector4.Lerp(from.GetRow(3), to.GetRow(3), t));
		return newMatrix;
	}

	void OnGUI()
	{
		//GUILayout.Label("New Camera.main.projectionMatrix:\n" + Camera.main.projectionMatrix.ToString());
		//if ( GUILayout.Button("更改CameraProjection") ) {
		//	ChangeProjection = true;
		//}
	}
}
