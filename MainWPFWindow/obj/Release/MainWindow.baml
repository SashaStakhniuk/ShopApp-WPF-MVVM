   M S B A M L   `   `   `  ���� H  DMainWPFWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MainWPFWindowMainWPFWindow      MainWPFWindow.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:MainWPFWindow       � Title$  
MainWindow��$	��768��$
��1377������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Black�� � Offset$ 0Q�� $ 	#FF30D5C8��$ 0.273Q�� $ 	#FF051716��$
 0.94Q�.���  � RowDefinitions �� $��* ��� $	��10* �.+�� $��0�� � ColumnDefinitions �� $	��100 ��� $
��1005 ��� $	��100 ��� $��80 ��� $��80 �.+��� -    ��Name$ ShowAddGoodsPanelButton��   ModernButton#��[  $��0��
�������$��30��$��30��$��Center=�$��Center=�.���� $(��"/bin/Debug/Images/AddPanelIcon.png��� $��1�� �� $��5* ��� $��1* �.+��� -    ��Name$ FindTB��$��0��$��0��$��Center=�$��Center=�$	��500��$��25��$��14(����	#FFE0E1E2�� -   $ 
FindButton��$��14(�
�������$��0��$��0��$��Center=�$��Right=�$��81��$��67��$��10q�.���� $%��/bin/Debug/Images/FindImage.png��$��30��$��30���� -   $ SignInButton��$��2��$��1��$��Create user 
account��$��	10,0,10,0q��� -   $ LogInButton��#��[  $��3��$��1��$��Log-In��$��10q��� -   $ BasketButton��#��[  $��4��$��1��$��Корзина��$��10q��� $��0��$��4��$��1��$��Stretch=�$��Bottom=�
���   �{�.  � $��1�� �� -   	 ��Name$	 AddPanelColumn��$��* ��� $
��Auto ��� $��5* �.+��� -   
 ��Name$
 CategoriesLB��$��5q�$��Stretch=����� ����  �� Color$ 	#FF30d5C8�� �� Opacity$	 0.1Q��� $��1��$��1�� �� ShowsPreview .  $��3��$��Center=�$��Stretch=��� -	    ��Name$ 	TBControl��$��2��
���   �$��2q�$��Stretch=�$��Stretch=�.@��� $��Goods����. .���� $
��Auto=�$
��Auto=�.���� -
   $
 GoodsListBox���� $
��Info��.���  �� $��7* ��� $��5* ��� .+��� $
��Auto=�$
��Auto=�.���� -    ��Name$ PhotoViewStackPanel��$��0�� �� Orientation$ 
Horizontal=�� $��1�� �� �� �� .+��� -   $ GoodInfoStackPanel��$ Vertical=�$��0���� -   $ GoodInfoStackPanel1��$ Vertical=�$��1���� -   $ GoodInfoStackPanel2��$ Vertical=�$��2���� -   $ 	BuyButton��$	��Buy��$��20(�$��2��$��Right=�$��Bottom=�$	��250��$��35��$��0,0,5,7q�