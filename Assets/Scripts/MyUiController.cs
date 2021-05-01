using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MyUiController : MonoBehaviour, IObserver<ITargetedProperty>
{
  public UIDocument UIDocument;
  public Button PropAddButton, PropSubButton, NextButton, PrevButton, PowerAddButton, PowerSubButton;
  public Label TargetNameLabel, PropNameLabel, PropValueLabel, PowerValueLabel;
  private IPropertyContainer _target;
  private ISpellSlot _ss;
  private VisualElement _root;
  void Start()
  {
    _ss = new SimpleSpellSlot(new SimpleMatcher(), GameObject.Find("Caster").GetComponent<SimplePropertyContainer>());
    _ss.Subscribe(this);

    _root = UIDocument.rootVisualElement;

    TargetNameLabel = _root.Q<Label>("TargetNameLabel");
    PropNameLabel = _root.Q<Label>("PropNameLabel");
    PropValueLabel = _root.Q<Label>("PropValueLabel");
    PowerValueLabel = _root.Q<Label>("PowerValueLabel");

    TargetNameLabel.text = "No unit selected";

    PropAddButton = _root.Q<Button>("PropValueAddButton");
    PropSubButton = _root.Q<Button>("PropValueSubButton");
    PowerAddButton = _root.Q<Button>("PowerAdd");
    PowerSubButton = _root.Q<Button>("PowerSub");
    PrevButton = _root.Q<Button>("Prev");
    NextButton = _root.Q<Button>("Next");

    PropAddButton.clickable.clicked += AddButtonClick;
    PropSubButton.clickable.clicked += SubButtonClick;
    PowerAddButton.clickable.clicked += AddPowerClick;
    PowerSubButton.clickable.clicked += SubPowerClick;
    PrevButton.clickable.clicked += PrevButtonClick;
    NextButton.clickable.clicked += NextButtonClick;
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Q))
    {
      PrevButtonClick();
      return;
    }
    if (Input.GetKeyDown(KeyCode.W))
    {
      NextButtonClick();
      return;
    }
    if (Input.GetKeyDown(KeyCode.A))
    {
      SubButtonClick();
      return;
    }
    if (Input.GetKeyDown(KeyCode.S))
    {
      AddButtonClick();
      return;
    }
    if (Input.GetKeyDown(KeyCode.Z))
    {
      SubPowerClick();
      return;
    }
    if (Input.GetKeyDown(KeyCode.X))
    {
      AddPowerClick();
      return;
    }

    if (Input.GetMouseButtonDown(0))
    {
      RaycastHit hitInfo = new RaycastHit();
      bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
      if (hit)
      {
        if (hitInfo.transform.gameObject.tag == "Selectable")
        {
          _ss.Target(hitInfo.transform.gameObject.GetComponent<SimplePropertyContainer>());
          TargetNameLabel.text = hitInfo.transform.gameObject.GetComponent<SimplePropertyContainer>().name;
        }
      }
      return;
    }
    if (Input.GetMouseButtonDown(1))
    {
      RaycastHit hitInfo = new RaycastHit();
      bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

      if (hit)
      {
        if (hitInfo.transform.gameObject.tag == "Selectable")
        {
          _ss.Target(hitInfo.transform.gameObject.GetComponent<SimplePropertyContainer>());
          TargetNameLabel.text = hitInfo.transform.gameObject.GetComponent<SimplePropertyContainer>().name;
        }
      }
      return;
    }
  }

  private void AddPowerClick()
  {
    _ss.TargetedProperty.CasterProp.Update(1);
  }

  private void SubPowerClick()
  {
    _ss.TargetedProperty.CasterProp.Update(-1);
  }

  private void AddButtonClick()
  {
    _ss.ApplyUpdate(true);
  }

  private void SubButtonClick()
  {
    _ss.ApplyUpdate(false);
  }

  private void PrevButtonClick()
  {
    _ss.TargetPrevProperty();
  }

  private void NextButtonClick()
  {
    _ss.TargetNextProperty();
  }

  public void OnCompleted()
  {
    throw new NotImplementedException();
  }

  public void OnError(Exception error)
  {
    throw new NotImplementedException();
  }

  public void OnNext(ITargetedProperty value)
  {
    PropNameLabel.text = value.CasterProp.Name;
    PropValueLabel.text = value.TargetProp.Value.ToString();
    PowerValueLabel.text = value.CasterProp.Value.ToString();
  }
}
