   M S B A M L   `   `   `  ����F  BMediaPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MediaPlayerMediaPlayer  5   	       MediaPlayer.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:MediaPlayer     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      � .+�5
   
   �� -   5         ��Name$
 play��5
      $
��Play��6   $
��Left=�6>   $��	31,22,0,0q�6Y   $	��Top=�6l   $��75��6�   r� 5   
   -   5         r�Name$ mediaElement��5      $
��Left=�6-   $	��203��6H   $��	31,82,0,0q�6U    r� LoadedBehavior$ Manual=�6h    r� UnloadedBehavior$
 Stop=�6�   $	��Top=�6�   $	��390��6�   �� 5   
   -   5        $ pause��5      $��Pause��6    $
��Left=�6A   $��
130,22,0,0q�6\   $	��Top=�6p   $��75��6�   {�.  6�   �� 5   
   -   5        $
 stop��5      $
��Stop��6   $
��Left=�6?   $��
232,22,0,0q�6Z   $	��Top=�6n   $��75��6�   {�.  6�   �� 5   
   -   5         ��Name$ txtFileName��5      $
��Left=�6'   $��23��6B   $��	31,54,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $��D:\CoffeeMaker.mp4��6u   $	��Top=�6�   $	��390��6�   �� 5   
   -   5        $ button3��5      $��Browse��6"   $
��Left=�63   $��
346,22,0,0q�6N   $	��Top=�6b   $��75��6z   6�   5      5      