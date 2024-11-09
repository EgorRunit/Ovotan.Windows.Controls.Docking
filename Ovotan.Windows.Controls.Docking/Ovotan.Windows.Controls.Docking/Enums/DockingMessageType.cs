namespace Ovotan.Windows.Controls.Docking.Enums
{
    /// <summary>
    /// Перичесление доступных сообщений для DockingManager
    /// </summary>
    public enum DockingMessageType
    {
        /// <summary>
        /// Панель была приклена к указанному краю хоста.
        /// В качестве аргумента события передается PanelAttachedMessage.
        /// </summary>
        PanelAttached,
        /// <summary>
        /// Паель была разделена на две новых паели.
        /// В качестве аргумента события передается PanelSplittedMessage.
        /// </summary>
        PanelSplitted,
        /// <summary>
        /// Панель была закрыта.
        /// В качестве аргумента события передается DockPanel.
        /// </summary>
        PanelClosed,
        /// <summary>
        /// Стартовало перетаскивания окна с панелью.
        /// В качестве аргумента события передается DockPlacementWindow.
        /// </summary>
        StartDraggingDockWindow,
        /// <summary>
        /// Показать окно с панелью.
        /// В качестве аргумента события передается FramworkElement.
        /// </summary>
        ShowDockPanelWindow,
    }
}
