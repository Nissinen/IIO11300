   M S B A M L   `   `   `  ����K  GSM-Liiga-tehtava, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SM_liigaSM_liiga  5   	       SM_liiga.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:SM_liiga     5   	     � Title$  
MainWindow��5   	   $	��350��6   $��657.353��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ btnLuo��5
      $��Luo uusi pelaaja��6!   $
��Left=�6<   $��
242,53,0,0q�6W   $	��Top=�6k   $��75��6�   6�   �� 5   
   -   5        $ 
btnTalleta��5      $��Talleta pelaaja��6%   $
��Left=�6?   $��
242,88,0,0q�6Z   $	��Top=�6n   $��75��6�   6�   �� 5   
   -   5        $ 	btnPoista��5      $��Poista pelaaja��6$   $
��Left=�6=   $��242,120,0,0q�6X   $	��Top=�6m   $��75��6�   6�   �� 5   
   -   5        $ btnKirjoita��5      $��Kirjoita pelaajat��6&   $
��Left=�6B   $��242,153,0,0q�6]   $	��Top=�6r   $��75��6�   6�   �� 5   
   -   5        $ 
btnLopetus��5      $��Lopetus��6%   $
��Left=�67   $��242,200,0,0q�6R   $	��Top=�6g   $��75��6   6�   �� 5   
   -   5         ��Name$ Etunimi��5      $
��Left=�6%   $��	10,51,0,0q�6@   $
��Wrap=�6S   $��Etunimi��6g   $	��Top=�6v    J� RenderTransformOrigin$ 0.198,0.824&�6�   �� 5   
   -   5        $ Sukunimi��5      $
��Left=�6&   $��	10,88,0,0q�6A   $
��Wrap=�6T   $��Sukunimi��6h   $	��Top=�6x   �� 5   
   -   5        $ Siirtohinta��5      $
��Left=�6)   $��
10,118,0,0q�6D   $
��Wrap=�6X   $��Siirtohinta��6l   $	��Top=�6   �� 5   
   -	   5        $ Serua��5      $
��Left=�6#   $��
10,155,0,0q�6>   $
��Wrap=�6R   $��Seura��6f   $	��Top=�6s   �� 5   
   -
   5         ��Name$ 
EtunimiTXT��5      $
��Left=�6&   $��23��6A   $��
108,50,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $��Teppo��6u   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ SukunimiTXT��5      $
��Left=�6'   $��23��6B   $��
108,84,0,0q�6N   $
 Wrap=�6b   $��Numminen��6v   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ SiirtohintaTXT��5      $
��Left=�6*   $��23��6E   $��108,117,0,0q�6Q   $
 Wrap=�6f   $
��5000��6z   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ listBox��5      $
��Left=�6#   $	��170��6>   $��
373,50,0,0q�6K   $	��Top=�6_   $	��247��6w   6�   �� 5   
   $
��Left=�6   $��23��6/   $��
10,286,0,0q�6;   $	��Top=�6O   $	��610��6g   .@�5      �� -   5        $ 	statusBar��5      $
��Wrap=�6+   $�� ��6?   5      �� 5   
   -   5         ��Name$ comboBox��5      $
��Left=�6%   $��108,155,0,0q�6@   $	��Top=�6U   $	��120��6m   .@�5      �� $��Tappara��6   $
��Left=�6-   $	��118��6H   �� 5      $��Pelicans��6   $
��Left=�6.   $	��118��6I   �� 5      $
��HIFK��6   $
��Left=�6*   $	��118��6E   �� 5      $	��JYP��6   $
��Left=�6)   $	��118��6D   5      �� 5    
   -   5        $ button��5       $��Lue Tiedosto��6!   $
��Left=�68   $��
33,205,0,0q�6S   $	��Top=�6g   $	��140��6   6�   5"      5#      