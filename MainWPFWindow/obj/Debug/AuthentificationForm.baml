   M S B A M L   `   `   `  ����H  DMainWPFWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MainWPFWindowMainWPFWindow  5   	   (    "MainWPFWindow.AuthentificationForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:MainWPFWindow     5   	     � Title$  AuthentificationForm��5   	   $	��450��6&   $	��800��63   ���	#FF30D5C8.��5
      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF323131��6   � 5      $ 	#FFF759FF��6    � Offset$
 0.45Q�61   � 5      $ 	#FF302E2E��6   $ 1Q�61   5       � ColumnDefinitions 5   
   �� 5      $��1* �6   6,   �� 5      $��5* �6   6,   �� 5      $��1* �6   6,    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��1��6   $��1��6   $��Log-in:��6-   $��Center=�6?   $
��Left=�6Z   $��14(�6u   $��30��6�   $��102,38,0,38q�6�   6�   �� 5   
   -   5         ��Name$ 
PasswordLB��5      $��2��6$   $��1��61   $��	Password:��6A   $	��Top=�6U   $
��Left=�6m   $��30��6�   $��14(�6�   $��	102,0,0,0q�6  6  �� 5    
   -   5         ��Name$ LoginTB��5       $��1��6#   $��1��63   $��286,37,80,38q�6@   $��Center=�6V   $��Center=�6q   $	��200��6�   $��30��6�   $��14(�6�   6�   G� 5!   
   -   5        	 G�Name$	 
PasswordPB��5!      $��1��6*   $��2��6:   $	��Top=�6G   $	��200��6`   $��30��6l   $��14(�6x   $��
286,0,80,0q�6�   � 5"   
   $��3��6   $��0��6   $��3��6,    5#      �� 5$      6%   �� 5%      6%   .+�5'      �� -   5        
 ��Name$
 AcceptButton��5'   ;      ModernButton#��[  6   $��Login��6Q   $��5q�6a   $��16(�6l   $��1��6z   $��3��6�   $��3��6�   6�   �� 5(      -   5        $
 CreateAccountButton��5(   ;   #��[  6   $��I don't have an account��6X   $��14(�6z   $��20q�6�   6�   5)      �� 5*   
   -   5        $ 
PasswordTB��5*      $y�Hidden=�6&   $��1��6:   $��2��6J   $	��200��6W   $��30��6c   $��14(�6o   $��286,36,80,39q�6}   �� 5+   
   6   5,      5-      