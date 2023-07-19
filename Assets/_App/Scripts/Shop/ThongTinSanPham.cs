using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThongTinSanPham : ManHinh
{
    public SanPhamUI SanPhamUi;
    public Button button, buttonSave;
    public TextMeshProUGUI text;
    private int ID;
    
    protected override void Start()
    {
        base.Start();
        button.onClick.AddListener(ShowInfoShop);
        buttonSave.onClick.AddListener(SaveSanPham);
    }

    void OnEnable()
    {
        
    }
    
    private void SaveSanPham()
    {
        var check =  GameDataManager.Instance.TickSave(ID);

        text.text = check ? "Bỏ lưu" : "Lưu";
    }


    public void SetInfo(SanPham product)
    {
    }

    public void ShowInfo(int id)
    {
        var sanPham = GameDataManager.Instance.SanPhamSo.GetSanPhamWithID(id);

        ID = id;
        SanPhamUi.SetInfo(sanPham);

        var check = GameDataManager.Instance.playerData.save.Contains(sanPham);

        text.text = check ? "Bỏ lưu" : "Lưu";
    }
    
    
    protected override void Back()
    {
        base.Back();
    }

    private void Save()
    {
        GameDataManager.Instance.TickSave(ID);
    }

    public void ShowInfoShop()
    {
        PurchasingManager.Instance.Show(ID);
    }

}