namespace December_2015_Exam.Interfaces
{
    using December_2015_Exam.Models.BehaviorTypes;

    /// <summary>
    /// Basic game character object.
    /// </summary>
    public interface IBlob
    {
        /// <summary>
        /// Returns the name of the blob.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets the health of the blob.
        /// </summary>
        int Health { get; set; }

        /// <summary>
        /// Returns the initial health of the blob.
        /// </summary>
        int InitialHealth { get; }

        /// <summary>
        /// Gets or sets the damage of the blob.
        /// </summary>
        int Damage { get; set; }

        /// <summary>
        /// Returns the initial damage of the blob.
        /// </summary>
        int InitialDamage { get; }

        /// <summary>
        /// Checks whether the blob is alive or not.
        /// </summary>
        bool IsAlive { get; }

        /// <summary>
        /// Returns the attack type of the blob.
        /// </summary>
        IAttack AttackType { get; }

        /// <summary>
        /// Returns the behavior type of the blob.
        /// </summary>
        Behavior BehaviorType { get; }

        /// <summary>
        /// Updates all blob stats.
        /// </summary>
        void Update();

        /// <summary>
        /// Attacks another blob.
        /// </summary>
        /// <param name="target">The blob which will be attacked.</param>
        void Attack(IBlob target);

        /// <summary>
        /// Response to an incoming attack.
        /// </summary>
        /// <param name="damage">Damage which will be applied.</param>
        void ResponseAttack(int damage);
    }
}
