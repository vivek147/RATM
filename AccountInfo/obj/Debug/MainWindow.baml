   M S B A M L   `   `   `  ����F  BAccountInfo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AccountInfoAccountInfo  5   	       AccountInfo.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   *Testclr-namespace:AccountInfo     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5      � .+�5   
   �� $��Center=�6   $��Center=�61    J� Opacity$ 0.765Q�6L   
�������$	��450��6m   $	��300��6z   �� 5	   
    �� CornerRadius$ 30��6   
�������$��0,0,0,0q�6=   ._�5      ��  �� Orientation$ Vertical=�6   .+�5      �� .+�5      �� $ 
Horizontal=�6!   .+�5      �� -   5        $
��Cmb1��5   #    �� 
IsEditable .  �� 
IsReadOnly .  �� Text$ Please Select Card��6S   $
��Left=�5      $��	10,10,0,0q�5      $	��Top=�5      $	��120��5      5      �� 5      -   5        $
��Cmb2��5   #   $y�	Collapsed=�6/    .  . $ 	Card Type��6j   $
��Left=�5      $��	70,10,0,0q�5      $	��Top=�5      $	��120��5      ��6;   �� 5      �� 5      -   5        $��Stack1��5   !   $	��213��6/   $ Vertical=�6<   $��
19,40,0,40q�6S   $y�Visible=�6g   $
��Auto=�6|   .+�5      �� -   5        $��stack2��5   %   $y�	Collapsed=�63   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��Grid1��5   '   $y�Visible=�64      RowBackground
 �����   CanUserAddRows .  	   AutoGenerateColumns	 .  
 J� RenderTransformOrigin$
 
0.46,0.308&�5    N   $��0,0,99,0q�6q   ��6   ��    Columns 5"   "   0  *System.Windows.Controls.DataGridTextColumn  5#   &   ,  &System.Windows.Controls.DataGridColumn   Header$ CARD NUMBER��69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6N   �� *CARD_NUMBER+  5$   &   $ 	CARD TYPE��69    6L   �� *	CARD_TYPE+  5%   &   $	 CVV��69    6F   �� *
CVV_NUMBER+  5&   &   $ CARDNAME��69    6K   �� *
CARDNAME+  5'   &   $ EXP MM��69    6I   �� *	EXPIRYM+  5(   &   $ EXP YYY��69    6J   �� *	EXPIRYY+   RowDetailsTemplate 5*   "   �� 5+   &   .R�5,   *   �� .+�5-   .   �� $��No Record Found��68   $	��400��6O   6]   5.   +   5/   '   ��52   "   �� 53   &    �� 
TargetType"  6,   .�54   *   ��  �� Property  �@ RowDetailsVisibilityMode �� Value$ 	Collapsed=�6U   6i    �� Triggers 55   *   �� 56   .    �� Binding 6:   �� *DataContext.IsRecordExists+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType   AccountInfo.MainWindow"   �� Value	 false58   N   .a�59   2   ��  �@ 	RowHeight$ 0Q�6N   6Z   �� 5:   2     �@ RowDetailsVisibilityMode$ Visible=�6]   6o   5;   /   5=   '   5@      �� 5B      $��Center=�6)   $ 
Horizontal=�6F   .+�5C   "   �� -   5        $��DeleteButton��5C   F   $��Delete��6)   $��24��6:   $��70��6Z   $��6q�6f   6q   �� 5D   "   -   5        $��UpdateButton��5D   F   $��Update��6)   $��24��6:   $��70��6Z   $��6q�6f   6q   5E      �� 5F      -   5         ��Name$ errormessage��5F   O   $��23��6(   $
��Left=�64   $	��Top=�6f   $	��247��6~   $��	118,2,0,0q�6�   ���	#FFE5572C6�   5G      �� 5I      $��20��6$   $	��139��60   $��Right=�6<   $��Center=�6X   $��
0,22,56,22q�6s   �� 5J      -	   5        $��13(�5J   0   $��Oblique$�6>   
���/kU�.�6n   Insert New Card Details6�   5K      5L      5M      5N      5O      5P      5Q      