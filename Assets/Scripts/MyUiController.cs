using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MyUiController : MonoBehaviour, IObserver<ITargetedProperty>
{
    public UIDocument UIDocument;
    public Button AddButton, SubButton, NextButton, PrevButton;
    public Label TargetNameLabel, PropNameLabel, PropValueLabel, PowerValueLabel;
    private IPropertyContainer _target;
    private ISpellSlot _ss;
    private VisualElement _root;

    void Start()
    {
        _ss = new SimpleSpellSlot(new SimpleMatcher(), GameObject.Find("Caster").GetComponent<SimplePropertyContainer>());
        _target = GameObject.Find("MyRock").GetComponent<SimplePropertyContainer>();
        _ss.Target(_target);
        _ss.Subscribe(this);

        _root = UIDocument.rootVisualElement;

        TargetNameLabel = _root.Q<Label>("TargetNameLabel");
        PropNameLabel = _root.Q<Label>("PropNameLabel");
        PropValueLabel = _root.Q<Label>("PropValueLabel");
        PowerValueLabel = _root.Q<Label>("PowerValueLabel");

        TargetNameLabel.text = "Rock";

        AddButton = _root.Q<Button>("AddButton");
        SubButton = _root.Q<Button>("SubButton");
        PrevButton = _root.Q<Button>("Prev");
        NextButton = _root.Q<Button>("Next");

        AddButton.clickable.clicked += AddButtonClick;
        SubButton.clickable.clicked += SubButtonClick;
        PrevButton.clickable.clicked += PrevButtonClick;
        NextButton.clickable.clicked += NextButtonClick;
    }

    void Update()
    {
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
