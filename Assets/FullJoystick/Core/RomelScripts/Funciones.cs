using System.Collections;
using UnityEngine;

public class Funciones : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public static float SacaDistancia (Vector3 Objetivo, Vector3 Yo){

		float Nx;
		float Ny;
		float Nz;

		float DistanciaDelObjetivo;

		float DistanciaExactaX = Objetivo.x - Yo.x;
		float DistanciaExactaY = Objetivo.y - Yo.y;
		float DistanciaExactaZ = Objetivo.z - Yo.z;

		if (DistanciaExactaX < 0f) {
			Nx = -1f;
		} else {
			Nx = 1f;
		}
		if (DistanciaExactaY < 0f) {
			Ny = -1f;
		} else {
			Ny = 1f;
		}
		if (DistanciaExactaZ < 0f) {
			Nz = -1f;
		} else {
			Nz = 1f;
		}

		//medidorexplosion = DistanciaExactaX * Nx + DistanciaExactaY * Ny + DistanciaExactaZ * Nz / 3f;

		float TotalDeYX = DistanciaExactaY * Ny + DistanciaExactaZ * Nz + DistanciaExactaX * Nx;
		float XPorcentaje = DistanciaExactaX * Nx / TotalDeYX;
		float YPorcentaje = DistanciaExactaY * Ny / TotalDeYX;
		float ZPorcentaje = DistanciaExactaZ * Nz / TotalDeYX;
		//DistanciaDelObjetivo = Mathf.Sqrt(((DistanciaExactaX * Nx)*(DistanciaExactaX*Nx)) + ((DistanciaExactaY * Ny)*(DistanciaExactaY * Ny)));
		DistanciaDelObjetivo = (DistanciaExactaX * Nx *(XPorcentaje)) + (DistanciaExactaY * Ny *(YPorcentaje)) + (DistanciaExactaZ * Nz *(ZPorcentaje));

		//transform.rotation = Quaternion.Euler (0f, FormulaExactaX, 0f);


		return DistanciaDelObjetivo;
	}
	public static Quaternion SacaGrados (Vector3 Objetivo, Vector3 Yo){
		float Nx;
		float Ny;
		float Nz;

		float DistanciaDelObjetivo;

		float DistanciaExactaX = Objetivo.x - Yo.x;
		float DistanciaExactaY = Objetivo.y - Yo.y;
		float DistanciaExactaZ = Objetivo.z - Yo.z;

		if (DistanciaExactaX < 0f) {
			Nx = -1f;
		} else {
			Nx = 1f;
		}
		if (DistanciaExactaY < 0f) {
			Ny = -1f;
		} else {
			Ny = 1f;
		}
		if (DistanciaExactaZ < 0f) {
			Nz = -1f;
		} else {
			Nz = 1f;
		}

		//medidorexplosion = DistanciaExactaX * Nx + DistanciaExactaY * Ny + DistanciaExactaZ * Nz / 3f;


		//DistanciaDelObjetivo = Mathf.Sqrt(((DistanciaExactaX * Nx)*(DistanciaExactaX*Nx)) + ((DistanciaExactaY * Ny)*(DistanciaExactaY * Ny)));

		//DistanciaDelObjetivo = DistanciaExactaX * Nx + DistanciaExactaZ * Nz / 2f;
		float TotalDeXZ = DistanciaExactaX * Nx + DistanciaExactaZ * Nz;
		float TotalDeYX = DistanciaExactaY * Ny + DistanciaExactaZ * Nz + DistanciaExactaX * Nx;
		float relacionXY = DistanciaExactaY + DistanciaExactaX;
		float relacionZX = DistanciaExactaZ + DistanciaExactaX;


		float FormulaExactaX = DistanciaExactaX * 100f / TotalDeXZ / 100f * 360 / 4f; //grados de la nave en relacion al vector x
		float FormulaExactaY = -DistanciaExactaY * 100f / TotalDeYX / 100f * 720 / 8f; //grados de la nave en relacion al vector y
		float FormulaExactaZ = DistanciaExactaZ * 100f / TotalDeYX / 100f * 360 / 4f; //grados de la nave en relacion al vector z
		float alineamientoEnX = (90f - FormulaExactaZ) * (Nx);


		if (DistanciaExactaZ < 0.000000000f) {
			FormulaExactaX = 180f - FormulaExactaX;
		}


		//transform.rotation = Quaternion.Euler (0f, FormulaExactaX, 0f);

		Quaternion MiRotacion = Quaternion.Euler (FormulaExactaY, FormulaExactaX, 0f);

		return MiRotacion;
	}
	public static float SacaDistanciaX (Vector3 Objetivo, Vector3 Yo){

		float Nx;
		float Ny;
		float Nz;

		float DistanciaDelObjetivo;

		float DistanciaExactaX = Objetivo.x - Yo.x;
		float DistanciaExactaY = Objetivo.y - Yo.y;
		float DistanciaExactaZ = Objetivo.z - Yo.z;

		if (DistanciaExactaX < 0f) {
			Nx = -1f;
		} else {
			Nx = 1f;
		}
		if (DistanciaExactaY < 0f) {
			Ny = -1f;
		} else {
			Ny = 1f;
		}
		if (DistanciaExactaZ < 0f) {
			Nz = -1f;
		} else {
			Nz = 1f;
		}

		//medidorexplosion = DistanciaExactaX * Nx + DistanciaExactaY * Ny + DistanciaExactaZ * Nz / 3f;


		//DistanciaDelObjetivo = Mathf.Sqrt(((DistanciaExactaX * Nx)*(DistanciaExactaX*Nx)) + ((DistanciaExactaY * Ny)*(DistanciaExactaY * Ny)));
		//DistanciaDelObjetivo = DistanciaExactaX * Nx + DistanciaExactaY * Ny + DistanciaExactaZ * Nz / 3f;

		//transform.rotation = Quaternion.Euler (0f, FormulaExactaX, 0f);


		return DistanciaExactaX;
	}
	public static float SacaDistanciaY (Vector3 Objetivo, Vector3 Yo){

		float Nx;
		float Ny;
		float Nz;

		float DistanciaDelObjetivo;

		float DistanciaExactaX = Objetivo.x - Yo.x;
		float DistanciaExactaY = Objetivo.y - Yo.y;
		float DistanciaExactaZ = Objetivo.z - Yo.z;

		if (DistanciaExactaX < 0f) {
			Nx = -1f;
		} else {
			Nx = 1f;
		}
		if (DistanciaExactaY < 0f) {
			Ny = -1f;
		} else {
			Ny = 1f;
		}
		if (DistanciaExactaZ < 0f) {
			Nz = -1f;
		} else {
			Nz = 1f;
		}

		//medidorexplosion = DistanciaExactaX * Nx + DistanciaExactaY * Ny + DistanciaExactaZ * Nz / 3f;


		//DistanciaDelObjetivo = Mathf.Sqrt(((DistanciaExactaX * Nx)*(DistanciaExactaX*Nx)) + ((DistanciaExactaY * Ny)*(DistanciaExactaY * Ny)));
		//DistanciaDelObjetivo = DistanciaExactaX * Nx + DistanciaExactaY * Ny + DistanciaExactaZ * Nz / 3f;

		//transform.rotation = Quaternion.Euler (0f, FormulaExactaX, 0f);


		return DistanciaExactaY;
	}
	public static float SacaDistanciaZ (Vector3 Objetivo, Vector3 Yo){

		float Nx;
		float Ny;
		float Nz;

		float DistanciaDelObjetivo;

		float DistanciaExactaX = Objetivo.x - Yo.x;
		float DistanciaExactaY = Objetivo.y - Yo.y;
		float DistanciaExactaZ = Objetivo.z - Yo.z;

		if (DistanciaExactaX < 0f) {
			Nx = -1f;
		} else {
			Nx = 1f;
		}
		if (DistanciaExactaY < 0f) {
			Ny = -1f;
		} else {
			Ny = 1f;
		}
		if (DistanciaExactaZ < 0f) {
			Nz = -1f;
		} else {
			Nz = 1f;
		}

		//medidorexplosion = DistanciaExactaX * Nx + DistanciaExactaY * Ny + DistanciaExactaZ * Nz / 3f;


		//DistanciaDelObjetivo = Mathf.Sqrt(((DistanciaExactaX * Nx)*(DistanciaExactaX*Nx)) + ((DistanciaExactaY * Ny)*(DistanciaExactaY * Ny)));
		//DistanciaDelObjetivo = DistanciaExactaX * Nx + DistanciaExactaY * Ny + DistanciaExactaZ * Nz / 3f;

		//transform.rotation = Quaternion.Euler (0f, FormulaExactaX, 0f);


		return DistanciaExactaZ;
	}
	public static float GradosAlineamientoEnX (Vector3 Objetivo, Vector3 Yo){
		float Nx;
		float Ny;
		float Nz;

		float DistanciaDelObjetivo;

		float DistanciaExactaX = Objetivo.x - Yo.x;
		float DistanciaExactaY = Objetivo.y - Yo.y;
		float DistanciaExactaZ = Objetivo.z - Yo.z;

		if (DistanciaExactaX < 0f) {
			Nx = -1f;
		} else {
			Nx = 1f;
		}
		if (DistanciaExactaY < 0f) {
			Ny = -1f;
		} else {
			Ny = 1f;
		}
		if (DistanciaExactaZ < 0f) {
			Nz = -1f;
		} else {
			Nz = 1f;
		}

		//medidorexplosion = DistanciaExactaX * Nx + DistanciaExactaY * Ny + DistanciaExactaZ * Nz / 3f;


		//DistanciaDelObjetivo = Mathf.Sqrt(((DistanciaExactaX * Nx)*(DistanciaExactaX*Nx)) + ((DistanciaExactaY * Ny)*(DistanciaExactaY * Ny)));

		//DistanciaDelObjetivo = DistanciaExactaX * Nx + DistanciaExactaZ * Nz / 2f;
		float TotalDeXZ = DistanciaExactaX * Nx + DistanciaExactaZ * Nz;
		float TotalDeYX = DistanciaExactaY * Ny + DistanciaExactaZ * Nz + DistanciaExactaX * Nx;
		float relacionXY = DistanciaExactaY + DistanciaExactaX;
		float relacionZX = DistanciaExactaZ + DistanciaExactaX;


		float FormulaExactaX = DistanciaExactaX * 100f / TotalDeXZ / 100f * 360 / 4f; //grados de la nave en relacion al vector x
		float FormulaExactaY = -DistanciaExactaY * 100f / TotalDeYX / 100f * 720 / 8f; //grados de la nave en relacion al vector y
		float FormulaExactaZ = DistanciaExactaZ * 100f / TotalDeYX / 100f * 360 / 4f; //grados de la nave en relacion al vector z
		float alineamientoEnX = (90f - FormulaExactaZ) * (Nx);


		if (DistanciaExactaZ < 0.000000000f) {
			FormulaExactaX = 180f - FormulaExactaX;
		}


		//transform.rotation = Quaternion.Euler (0f, FormulaExactaX, 0f);

		//Quaternion MiRotacion = Quaternion.Euler (FormulaExactaY, FormulaExactaX, 0f);

		return alineamientoEnX;
	}
	public static float NzDevuelve (Vector3 Objetivo, Vector3 Yo){
		float Nx;
		float Ny;
		float Nz;

		float DistanciaDelObjetivo;

		float DistanciaExactaX = Objetivo.x - Yo.x;
		float DistanciaExactaY = Objetivo.y - Yo.y;
		float DistanciaExactaZ = Objetivo.z - Yo.z;

		if (DistanciaExactaX < 0f) {
			Nx = -1f;
		} else {
			Nx = 1f;
		}
		if (DistanciaExactaY < 0f) {
			Ny = -1f;
		} else {
			Ny = 1f;
		}
		if (DistanciaExactaZ < 0f) {
			Nz = -1f;
		} else {
			Nz = 1f;
		}

		//medidorexplosion = DistanciaExactaX * Nx + DistanciaExactaY * Ny + DistanciaExactaZ * Nz / 3f;


		//DistanciaDelObjetivo = Mathf.Sqrt(((DistanciaExactaX * Nx)*(DistanciaExactaX*Nx)) + ((DistanciaExactaY * Ny)*(DistanciaExactaY * Ny)));

		//DistanciaDelObjetivo = DistanciaExactaX * Nx + DistanciaExactaZ * Nz / 2f;
		float TotalDeXZ = DistanciaExactaX * Nx + DistanciaExactaZ * Nz;
		float TotalDeYX = DistanciaExactaY * Ny + DistanciaExactaZ * Nz + DistanciaExactaX * Nx;
		float relacionXY = DistanciaExactaY + DistanciaExactaX;
		float relacionZX = DistanciaExactaZ + DistanciaExactaX;


		float FormulaExactaX = DistanciaExactaX * 100f / TotalDeXZ / 100f * 360 / 4f; //grados de la nave en relacion al vector x
		float FormulaExactaY = -DistanciaExactaY * 100f / TotalDeYX / 100f * 720 / 8f; //grados de la nave en relacion al vector y
		float FormulaExactaZ = DistanciaExactaZ * 100f / TotalDeYX / 100f * 360 / 4f; //grados de la nave en relacion al vector z
		float alineamientoEnX = (90f - FormulaExactaZ) * (Nx);


		if (DistanciaExactaZ < 0.000000000f) {
			FormulaExactaX = 180f - FormulaExactaX;
		}


		//transform.rotation = Quaternion.Euler (0f, FormulaExactaX, 0f);

		//Quaternion MiRotacion = Quaternion.Euler (FormulaExactaY, FormulaExactaX, 0f);

		return Nz;
	}
	public static Vector3 RotacionToPosicion (Vector3 Vyo, Quaternion Qyo, Vector3 NegProfundidadZ){
		Vector3 Final = Qyo * NegProfundidadZ + Vyo;
		return Final;
	}
}