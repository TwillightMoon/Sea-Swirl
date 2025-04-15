using UnityEngine;
using UnityEngine.Serialization;

public class WaterManager : Singleton<WaterManager>
{
   [FormerlySerializedAs("_waterSettings")] [SerializeField]
   private ShaderWaterSettings _shaderWaterSettings;

   public ShaderWaterSettings shaderWaterSettings => _shaderWaterSettings;
   
   public float waterLevel =>  transform.position.y;

   public float GetWaveHeight(Vector3 point, float time)
   {
      return transform.TransformPoint(Displacement(point, time)).y;
   }

   public Vector3 Displacement(Vector3 point, float timing)
   {
      Vector3 displacement1 = GerstnerWave(point, _shaderWaterSettings.Direction1, shaderWaterSettings.WaveAmplitude.x, timing / _shaderWaterSettings.TimeScale.x);
      Vector3 displacement2 = GerstnerWave(point, _shaderWaterSettings.Direction2, shaderWaterSettings.WaveAmplitude.y, timing / _shaderWaterSettings.TimeScale.y);
      Vector3 displacement3 = GerstnerWave(point, _shaderWaterSettings.Direction3, shaderWaterSettings.WaveAmplitude.z, timing / _shaderWaterSettings.TimeScale.z);
      Vector3 displacement4 = GerstnerWave(point, _shaderWaterSettings.Direction4, shaderWaterSettings.WaveAmplitude.w, timing / _shaderWaterSettings.TimeScale.w);
      
      return displacement1 + displacement2 + displacement3 + displacement4;
   }

   private Vector3 GerstnerWave(Vector3 point, Vector3 direction, float waveAmplitude, float timing)
   {
      float theta = GetTheta(point, direction, timing);

      return new Vector3(-GetCoordinate(direction.x), GetY(), -GetCoordinate(direction.z));

      float GetY()
      {
         return Mathf.Cos(theta) * waveAmplitude;
      }

      float GetCoordinate(float axisCoordinate)
      {
         float amplitudePerHyperbolicLengthX = waveAmplitude / HyperbolicTangent(direction.magnitude * _shaderWaterSettings.WaveDepth);

         float directionXToLength = axisCoordinate / direction.magnitude;

         return Mathf.Sin(theta) * directionXToLength * amplitudePerHyperbolicLengthX;
      }
   }

   private float GetTheta(Vector3 point, Vector3 direction, float timing)
   {
      float positionDirectionX = point.x * direction.x;
      float positionDirectionZ = point.z * direction.z;

      float sum = positionDirectionX + positionDirectionZ;

      float multFrequency = GetFrequency(direction, timing) * timing;
      
      return sum - multFrequency - _shaderWaterSettings.Phase;
   }

   private float GetFrequency(Vector3 direction, float timing)
   {
      float length = direction.magnitude;
      float gLength = _shaderWaterSettings.Gravity * length;

      float dLength = _shaderWaterSettings.WaveDepth * length;
      float  hyperbolicTang = HyperbolicTangent(dLength);

      return Mathf.Sqrt(hyperbolicTang * gLength);
   }
   
   public float HyperbolicTangent(float x)
   {
      float exp2x = Mathf.Exp(2 * x);
      return (exp2x - 1) / (exp2x + 1);
   }
}


