
public class BankInteractor : Interactor
{
    private BankRepository _repository;

    public int coins => this._repository.coins;

    public BankInteractor(BankRepository repository)
    {
        this._repository = repository;
    }

    public override void Initialize()
    {
        Bank.Initialize(this);
    }

    public bool IsEnougthCoins(int value)
    {
        return coins >= value;
    }

    public void AddCoins(object sender, int value)
    {
        this._repository.coins += value;
        this._repository.Save();
    }

    public void Spend(object sender, int value)
    {
        this._repository.coins -= value;
        this._repository.Save();
    }
}
