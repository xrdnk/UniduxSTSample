using UnityEngine.EventSystems;

namespace Deniverse.UniduxSTSample.View
{
    public abstract class UIViewBase : UIBehaviour
    {
        /// <summary>
        /// ビューの表示処理
        /// </summary>
        public void Show() => gameObject.SetActive(true);

        /// <summary>
        /// ビューの非表示処理
        /// </summary>
        public void Hide() => gameObject.SetActive(false);
    }
}