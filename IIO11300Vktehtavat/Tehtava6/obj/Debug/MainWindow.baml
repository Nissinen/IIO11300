   M S B A M L   `   `   `  ����C  ?Tehtava6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Tehtava6Tehtava6  5   	       Tehtava6.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Tehtava6     5   	     � Title$  
MainWindow��5   	   $	��550��6   $	��525��6)   .��5	      � .+�5
   
   �� ��5      �� 5       �� 
StartPoint$	 1,1&�6&    �� EndPoint$	 0,1&�67   .��5      �  � Color$	 Red��6#    � Offset$
 0.05Q�6/   � 5      $ Black��6#   $	 0.8Q�61   5      ._�5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ 	btnGetXML��5      $��
Hae Viinit��60   $	��100��6E   $��
100,10,0,0q�6i   �� 5      -   5         ��Name$ 
CBWineList��5      $	��100��63   $��
100,10,0,0q�6?   .@�5      �� $��Kaikki��6'   $
��Left=�68   $��98��6S   �� 5      $��Suomi��6'   $
��Left=�67   $��98��6R   �� 5      $��France��6'   $
��Left=�68   $��98��6S   �� 5      $��Hungary��6'   $
��Left=�69   $��98��6T   �� 5      $��Chile��6'   $
��Left=�67   $��98��6R   �� 5      $��Romanien��6'   $
��Left=�6:   $��98��6U   �� 5      $��South Africa��6'   $
��Left=�6>   $��98��6Y   5      5      �� 5      $��50,50,50,50q�6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dgData��5      	   AutoGenerateColumns	 .  ��6+   �� 
   Columns
 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Maisteltu Viini��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   ��  �� Path$ Element[nimi].Value�6u     5"      $ Pojoja��6-    6=   �� $ Element[arvio].Value�6m     5#      $ 
Valmistetu��61    6E   �� $ Element[maa].Value�6s   5%      �� 5&      -   5         ��Name$ 	tbMessage��5&      $	��...��6/   $�� 0,0,0,0q�6:   ���	#FFCFB6166e   5'      5(      5)      5*      5+      