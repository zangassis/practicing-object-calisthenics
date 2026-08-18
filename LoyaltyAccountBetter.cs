namespace PracticingObjectCalisthenics
{
    public class LoyaltyAccountBetter
    {
        private int _points;

        public int Points => _points;

        public void EarnPoints(int points)
        {
            if (points <= 0)
                throw new DomainException(
                    "Points must be greater than zero.");

            _points += points;
        }

        public void RedeemPoints(int points)
        {
            if (points <= 0)
                throw new DomainException(
                    "Points must be greater than zero.");

            if (points > _points)
                throw new DomainException(
                    "Insufficient points.");

            _points -= points;
        }
    }
}
