using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    ShapeSettings shapeSettings;
    INoiseFilter[] noiseFilters;
    public MinMax elevationMinMax;

    public void UpdateSettings(ShapeSettings shapeSettings)
    {
        this.shapeSettings = shapeSettings;
        noiseFilters = new INoiseFilter[shapeSettings.noiseLayers.Length];

        for(int i = 0; i < noiseFilters.Length; i++)
        {
            noiseFilters[i] = NoiseFilterFactory.CreateNoiseFilter(shapeSettings.noiseLayers[i].noiseSettings);
        }

        elevationMinMax = new MinMax();
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnunitSphere)
    {
        float elevation = 0;

        float firstLayervalue = 0;
        if(noiseFilters.Length > 0)
        {
            firstLayervalue = noiseFilters[0].Evaluate(pointOnunitSphere);
            if(shapeSettings.noiseLayers[0].enabled){
                elevation = firstLayervalue;
            }
        }
        
        for(int i = 1; i < noiseFilters.Length; i++)
        {
            float mask = (shapeSettings.noiseLayers[i].useFirstLayerAsMask) ? firstLayervalue : 1;
            if(shapeSettings.noiseLayers[i].enabled)
                elevation += noiseFilters[i].Evaluate(pointOnunitSphere) * mask;
        }
         elevation = shapeSettings.planetRadius * (1 + elevation);

        elevationMinMax.AddValue(elevation);

        return pointOnunitSphere * elevation;
    }
}
