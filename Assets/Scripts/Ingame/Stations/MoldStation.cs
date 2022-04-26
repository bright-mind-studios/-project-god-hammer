using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoldStation : WorkStation
{
    [SerializeField] private List<WeaponShape> shapes;
    [SerializeField] private int currentType;
    [SerializeField] private int currentShape;
    [SerializeField] private Mold mold;   
    [SerializeField] private RayCutterInteractable rayCutter; 
    [SerializeField] private int shapesPerType = 2;
    [SerializeField] private ButtonInteractable[] shapeSelectors;
    private void Start() 
    {        
        selectShape(0);
        
    }   

    public new void OnEnable() 
    {
        base.OnEnable();
        for(int i = 0; i <= shapeSelectors.Length; i++){
            shapeSelectors[i].OnPressButton += ()=> swapShape(i);
        }        
    }

    public new void OnDisable() 
    {
        base.OnDisable();
        for(int i = 0; i <= shapeSelectors.Length; i++){
            shapeSelectors[i].OnPressButton -= ()=> swapShape(i);
        }
    }

    public void swapShape(int type)
    {
        if (currentType == type)
            currentShape =  (currentShape + 1) % shapesPerType;
        else{
            currentType = type;
            currentShape = 0;
        }        
        selectShape(currentType * shapesPerType + currentShape);
    }

    private void selectShape(int id){
        mold.renderTemplateShape(shapes[id].points.ToArray());       
    }

    public override bool IsValidResource(Resource resource)
    {
        return resource is Metal;
    }

    public override void ProcessResource(Resource resource)
    {
        TriggerInputZone(false);
        // Generar el arma con el molde
        //ReleaseOutputResource(...)
    }   
}
