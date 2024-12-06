using UnityEngine;

[RequireComponent (typeof(CellHendRight))]

public class Hends : MonoBehaviour
{
    private const string CudgelName = "Cudgel";
    //private const string AxeName = "Axe";

    [SerializeField] private GameObject _hend;
    private bool _isVoidHend;

    [SerializeField] private GameObject _cudgel;
    private bool _isCudgel;

    //[SerializeField] private GameObject _axe;
    private bool _isAxe;

    [SerializeField] private Entity _entity;

    private CellHendRight _rightHend;

    private void Start()
    {
        _rightHend = GetComponent<CellHendRight>();
    }

    private void Update()
    {
        SwitchWeapon();
    }

    private void CheckToWeapon()
    {
        if(_rightHend.Item_SO == null)
        {
            _isVoidHend = true;
            _isCudgel = false;
            _isAxe = false;
        }
        else if(_rightHend.Item_SO.Name == CudgelName)
        {
            _isVoidHend = false;
            _isCudgel = true;
            _isAxe = false;
        }
        else if (_rightHend.Item_SO.Name == CudgelName)
        {
            _isVoidHend = false;
            _isCudgel = false;
            _isAxe = true;
        }
    }

    private void SwitchWeapon()
    {
        CheckToWeapon();

        if (_isVoidHend)
        {
            _hend.SetActive(true);
            _cudgel.SetActive(false);
           // _axe.SetActive(false);
        }
        else if (_isCudgel)
        {
            _hend.SetActive(false);
            _cudgel.SetActive(true);
            //_axe.SetActive(false);
        }
        else if (_isAxe)
        {
            _hend.SetActive(false);
            _cudgel.SetActive(false);
            //_axe.SetActive(true);
        }
    }

    public int Attack()
    {
        if (_isVoidHend)
        {
            return _entity.Damage;
        }
        else
        {
            return _entity.Damage + _rightHend.Item_SO.WeaponSO.Damage;
        }
    }
}
