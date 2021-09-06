using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Character 
{
    public string nombre;
    public bool pNatural;
    public bool empresa;
    public string nombreEmpresa;
    public string cargo;
    public string correo;

    public Character(string nombre, bool pNatural, bool empresa, string nombreEmpresa, string cargo, string correo)
    {
        this.nombre = nombre;
        this.pNatural = pNatural;
        this.empresa = empresa;
        this.nombreEmpresa = nombreEmpresa;
        this.cargo = cargo;
        this.correo = correo;
    }
}
public class CharacterData : MonoBehaviour
{
    public InputField nombreInput;
    public Toggle personaNaturalToggle;
    public Toggle empresaToggle;
    public InputField nombreEmpresaInput;
    public InputField cargoInput;
    public InputField correoInput;

    private void Awake() 
    {
        nombreInput.characterLimit = 20;
        nombreEmpresaInput.characterLimit = 20;
        cargoInput.characterLimit = 40;
        correoInput.characterLimit = 40;
    }
    

    public Character ReturnClass()
    {
        return new Character(nombreInput.text, personaNaturalToggle.isOn, empresaToggle.isOn, nombreEmpresaInput.text, cargoInput.text, correoInput.text);
    }

    public void SetUi(Character character)
    {
        nombreInput.text = character.nombre;
        personaNaturalToggle.isOn = character.pNatural;
        empresaToggle.isOn = character.empresa;
        nombreEmpresaInput.text = character.nombre;
        cargoInput.text = character.cargo;
        correoInput.text = character.correo;
    }
}
