   M S B A M L   `   `   `  ���� H  DMainWPFWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MainWPFWindowMainWPFWindow  %    MainWPFWindow.AdministratorForm   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:MainWPFWindow       � Title$  AdministratorForm��$	��450��$	��800��.��� .+��� -    ��Name$ AdminTabControl��$��16(�$��2��
���   �$��2q�$��Stretch=�$��Stretch=�.@��� $��CustomersDB����. .���  � RowDefinitions �� $��5* ��� $��1* �.+�� $��0��.+�&   System.Windows.Controls.DataGrid  -     Name$ dataGridPersons��   AutoGenerateColumns .     SelectionMode$ Extended=�$
��Auto��$��0��$��2��$��3,10,3,0q�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto    Header$ 
CustomerId��1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *
PersonId+  $
 auto $ 	FirstName��	 �� *	FirstName+  $
 auto $ LastName��	 �� *
LastName+  $
 auto $ Email��	 �� *Email+  $
 auto $
 Role��	 �� *Role+  $
 auto $ Login��	 �� *Login+  $
 auto $ Password��	 �� *
Password+� $��1��
 � ColumnDefinitions
 �� �� �� .+��� -    ��Name$ AddNewPersonButton��$��
Add Person��$��0��$��20(�$��8q��� -   $ EditPersonButton��$��Edit Person��$��1��$��20(�$��8q��� -   $ DeletePersonButton��$��Remove Person��$��2��$��20(�$��8q��� $��Goods��.���  �� $��5* ��� $��1* �.+�� $��0��.+�  -   $ dataGridGoods�� .  $
��Auto��$��0��$��3,10,3,0q�����    $
 auto $ GoodId��	 �� *GoodId+  $
 auto $ GoodName��	 �� *
GoodName+  $
 auto $ ManufacturerId��	 �� *ManufacturerId+  $
 auto $ 
CategoryId��	 �� *
CategoryId+  $
 auto $ PhotoId��	 �� *	PhotoId+  $
 auto $ Price��	 �� *Price+  $
 auto $ 	GoodCount��	 �� *	GoodCount+� $��1��
 �� �� �� .+��� -   $ AddGoodButton��$��Add Good��$��20(�$��0��$��8q��� -   $ EditGoodButton��$��	Edit Good��$��20(�$��1��$��8q��� -	   $ RemoveGoodButton��$��Remove Good��$��20(�$��2��$��8q��� $��
Categories��.���  �� $��5* ��� $��1* �.+�� $��0��.+�  -
   $ dataGridCategories�� .  $
��Auto��$��0��$��3,10,3,0q�����    $
 auto $ 
CategoryId��	 �� *
CategoryId+  $
 auto $ CategoryName��	 �� *CategoryName+� $��1��
 �� �� �� .+��� -   $ AddCategoryButton��$��Add Category��$��20(�$��0��$��8q��� -   $ EditCategoryButton��$��Edit Category��$��20(�$��1��$��8q��� -   $ RemoveCategoryButton��$��Remove Category��$��20(�$��2��$��8q��� $��Manufacturers��.���  �� $��5* ��� $��1* �.+�� $��0��.+�  -   $ dataGridManufacturers�� .  $
��Auto��$��0��$��3,10,3,0q�����    $
 auto $ ManufacturerId��	 �� *ManufacturerId+  $
 auto $ ManufacturerName��	 �� *ManufacturerName+� $��1��
 �� �� �� .+��� -   $ AddManufacturyButton��$��Add Manufactury��$��20(�$��0��$��8q��� -   $ EditManufacturyButton��$��Edit Manufactury��$��20(�$��1��$��8q��� -   $ RemoveManufacturyButton��$��Remove Manufactury��$��20(�$��2��$��8q��� $��Photos��.���  �� $��5* ��� $��1* �
 �� �� .+�� $��0��$��0��.+�  -   $ dataGridPhotos�� .  $
��Auto��$��3,10,3,0q�����    $
 auto $ PhotoId��	 �� *	PhotoId+  $
 auto $ PhotoAddress��	 �� *PhotoAddress+�� $��0��$��1��.���� -    ��Name$ PhotoViewStackPanel��� $��1��$��2��
 �� �� �� .+��� -   $ AddPhotoButton��$��	Add Photo��$��20(�$��0��$��8q��� -   $ EditPhotoButton��$��
Edit Photo��$��20(�$��1��$��8q��� -   $ RemovePhotoButton��$��Remove Photo��$��20(�$��2��$��8q��� $��Receipts����. .���  �� $��5* ��� $��1* �.+�� $��0��.+�  -   $ dataGridReceipts�� .  $ Extended=�$
��Auto��$��0��$��2��$��3,10,3,0q�����    $
 auto $ 	ReceiptId��	 �� *	ReceiptId+  $
 auto $ PersonId��	 �� *
PersonId+  $
 auto $ GoodId��	 �� *GoodId+  $
 auto $ Price��	 �� *Price+  $
 auto $ Amount��	 �� *Amount+  $
 auto $ Discount��	 �� *
Discount+  $
 auto $ GeneralPrice��	 �� *GeneralPrice+  $
 auto $ BuyTime��	 �� *	BuyTime+� $��1��
 �� �� �� .+��� -   $ EditReceiptButton��$��Edit Receipt��$��1��$��20(�$��8q��� -   $ DeleteReceiptButton��$��Remove Receipt��$��2��$��20(�$��8q�