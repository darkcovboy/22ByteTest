using System.Collections.Generic;

namespace BasketScripts
{
    public class BusketButtonManager
    {
        private List<BusketButton> _busketButtons;

        public BusketButtonManager()
        {
            _busketButtons = new List<BusketButton>();
        }

        public void AddBusketButton(BusketButton busketButton) => _busketButtons.Add(busketButton);

        public void UnselectButtons()
        {
            foreach (var busketButton in _busketButtons)
            {
                busketButton.Unselect();
            }
        }
    }
}