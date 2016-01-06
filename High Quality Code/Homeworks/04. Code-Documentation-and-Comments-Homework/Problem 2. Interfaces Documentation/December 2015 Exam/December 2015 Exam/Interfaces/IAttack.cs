namespace December_2015_Exam.Interfaces
{
    /// <summary>
    /// Order a blob to attack another one.
    /// </summary>
    public interface IAttack
    {
        /// <summary>
        /// Calculates the attack damage.
        /// </summary>
        /// <param name="parent">Blob which will attack.</param>
        /// <returns>Damage which will be applied on the other blob</returns>
        int ProduceAttack(IBlob parent);
    }
}
