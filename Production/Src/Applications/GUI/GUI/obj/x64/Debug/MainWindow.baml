   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI  5   	   C ?SAD.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?-clr-namespace:SAD.Core.Data;assembly=SAD.CoreSAD.Core.Data 5   	   -clr-namespace:GUI.ViewModelGUI.ViewModel  5   	       GUI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   !guiclr-namespace:GUI     5   	   >data-clr-namespace:SAD.Core.Data;assembly=SAD.Core     5   	   *hiclr-namespace:GUI.ViewModel     5   	     � Title$  
MainWindow��5   	   $	��600��5	   	   $	��800��5
   	    � 	Resources 5         GUI.mainViewModel   	MainModel   GUI.launcherViewModel  launcherModel   GUI.videoViewModel  
videoModel  SAD.Core.Data.Target  targetClass  myBrush !� Visual  myOtherBtnStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color   ShadowDepth   
BlurRadius	 �� 
TargetType
 � Points 
� Center 
� RadiusX 
� RadiusY 
� GradientOrigin � Color � Offset �� Triggers P� Property P� Value �� 
TargetName  myOtherBtnStyle1  
myBtnStyle��%�  &	        &	      &	 &     &	 9     &	 L     &	 �     &	     &	 k      5   
   6     5   
   6      5   
   6     5   
   6   !� 5   
    5      � 5      .+�5      �� 
���  ��6    �� 5      $��Images/camo.png��6   5      5      �� 5   
   " ��6(   .�5      ��  � �� 6&   �� *Width+6@   �� 5       � �� 6'   �� *Height+6B   �� 5       �@J�Effect 5        5      $ White��6'   $ 0Q�65   $ 10Q�6E   6W   5       �� 5!       � �� 5"      �� 5#      "	 ��6&   .R�5$      � .+�5%      � $��myOne��6?   
 �   @x}��� �����5&   "   
� 5'   &   $ 0.5, 0.5&�6:   $	 0.5Q�6L   $	 0.5Q�6Z   $ 0.4, 0.3&�5(   :   .��5)   *   � $ 
WhiteSmoke��67   $	 0.0Q�6J   5*   +   � 5+   *   $ Orange��67   $	 0.8Q�6F   6U   5,   '   5.      �� 5/      $��Center=�6/   $��Center=�6L   6i   50       51      P� 52       �@J�IsMouseOver . . �53   "   �� $ myOne��69    � �� 54   &   
� 55   *   $ 0.5, 0.5&�6>   $	 0.5Q�6P   $	 0.5Q�6^   $ 0.6, 0.3&�56   :   .��57   .   � $ 
WhiteSmoke��6;   $	 0.2Q�6N   58   /   � 59   .   $
 Blue��6;   $	 0.8Q�6H   6W   5:   +   5<   #   5=      P� 5>       � �� . . �5?   "   �� $ myOne��69    � �� 5@   &   
� 5A   *   $ 0.5, 0.5&�6>   $	 0.5Q�6P   $	 0.5Q�6^   $ 0.6, 0.3&�5B   :   .��5C   .   � $ 
WhiteSmoke��6;   $	 0.0Q�6N   5D   /   � 5E   .   $	 Red��6;   $	 0.8Q�6G   6V   5F   +   5H   #   5I      5K      5M      5N      �� 5O   
   " ��6)   .�5P      ��  � �� 6&   �� *Width+6@   �� 5Q       � �� 6'   �� *Height+6B   �� 5R       �@J�Effect 5S        5T      $ White��6'   $ 0Q�65   $ 10Q�6E   6W   5V      �� 5W       � �� 5X      �� 5Y      "	 ��6&   .R�5Z      � .+�5[      � $��myOne��6@   
 �   @x}��� @x}�����5\   "   
� 5]   &   $ 0.5, 0.5&�6:   $	 0.5Q�6L   $	 0.5Q�6Z   $ 0.4, 0.3&�5^   :   .��5_   *   � $ 
WhiteSmoke��67   $	 0.0Q�6J   5`   +   � 5a   *   $ Orange��67   $	 0.8Q�6F   6U   5b   '   5d      �� 5e      $��Center=�6/   $��Center=�6L   6i   5f       5g      P� 5h       �@J�IsMouseOver . . �5i   "   �� $ myOne��69    � �� 5j   &   
� 5k   *   $ 0.5, 0.5&�6>   $	 0.5Q�6P   $	 0.5Q�6^   $ 0.6, 0.3&�5l   :   .��5m   .   � $ 
WhiteSmoke��6;   $	 0.2Q�6N   5n   /   � 5o   .   $
 Blue��6;   $	 0.8Q�6H   6W   5p   +   5r   #   5s      P� 5t       � �� . . �5u   "   �� $ myOne��69    � �� 5v   &   
� 5w   *   $ 0.5, 0.5&�6>   $	 0.5Q�6P   $	 0.5Q�6^   $ 0.6, 0.3&�5x   :   .��5y   .   � $ 
WhiteSmoke��6;   $	 0.0Q�6N   5z   /   � 5{   .   $	 Red��6;   $	 0.8Q�6G   6V   5|   +   5~   #   5      5�      5�      5�      �� 5�   
   " ��6#   .�5�      ��  � �� 6&   �� *Width+6@   �� 5�       � �� 6'   �� *Height+6B   �� 5�       �@J�Effect 5�        5�      $ White��6'   $ 0Q�65   $ 10Q�6E   6W   5�      �� 5�       � �� 5�      �� 5�      "	 ��6&   .R�5�      � .+�5�      A� $��myele��6&   ��5�   "   
� 5�   &   $ 0.5, 0.5&�6:   $	 0.5Q�6L   $	 0.5Q�6Z   $ 0.6, 0.3&�5�   :   .��5�   *   � $ 
WhiteSmoke��67   $	 0.0Q�6J   5�   +   � 5�   *   $	 Red��67   $	 0.8Q�6C   6R   5�   '   5�      �� 5�      $��Center=�6/   $��Center=�6L   6i   5�       5�      P� 5�       �@J�IsMouseOver . . �5�   "   �� $ myele��69    � �� 5�   &   
� 5�   *   $ 0.5, 0.5&�6>   $	 0.5Q�6P   $	 0.5Q�6^   $ 0.6, 0.3&�5�   :   .��5�   .   � $ 
WhiteSmoke��6;   $	 0.0Q�6N   5�   /   � 5�   .   $ Orange��6;   $	 0.8Q�6J   6Y   5�   +   5�   #   5�      P� 5�       � �� . . �5�   "   �� $ myele��69    � �� 5�   &   
� 5�   *   $ 0.5, 0.5&�6>   $	 0.5Q�6P   $	 0.5Q�6^   $ 0.6, 0.3&�5�   :   .��5�   .   � $ 
WhiteSmoke��6;   $	 0.0Q�6N   5�   /   � 5�   .   $
 Blue��6;   $	 0.8Q�6H   6W   5�   +   5�   #   5�      5�      5�      5�      5�      .��5�      � #��[ 6   .+�5�   
   �� $��Right=�6   $��18��6.    �� TextWrapping$
 Wrap=�6:   $��Targets��6N    �� TextAlignment$ Center=�6]   $	��Top=�6t   $	��150��6�   $��1��6�   �� 5�   
   -   5        $��ListofTargets��5�       � DataContext# [  5�      $��1��5�      $��0,23,0,0q�6   ��5�      �� *	Targets+��5�      �� 5�       �� DataType"  6    .R�5�         GUI.TargetView  5�      5�      �� 5�   
   -   5         ��Name$ Timer��5�      $
��Left=�6!   $��20��6<   $��	189,2,0,0q�6H   $
 Wrap=�6[   $��Timer��6o   $	��Top=�6|   $	��124��6�   $��1��6�   �� 5�   
   -   5        $ Position��5�      $
��Left=�5�      $��21��6-   $��	363,4,0,0q�69   $
 Wrap=�6L   $'��!Position (          ,           )��5�      $	��Top=�6;    �� 
IsReadOnly . $	��135��5�      $��1��6   $��2��6.   �� 5�   
   -   5        $ Score��5�      $
��Left=�6!   $��21��6<   $��2,4,0,0q�6H   $
 Wrap=�6Y   $��Score��6m   $	��Top=�6z   $	��117��6�   $��2��6�   $��1��6�   �� 5�   
   -   5        $ Missiles��5�      $
��Left=�5�      $��21��5�      $��	191,4,0,0q�5�      $
 Wrap=�5�      $��Missiles Left: ��5�       . $	��Top=�5�      $	��117��5�      $��2��5�      $��1��5�      �� 5�   
   -   5        $
 Game��5�      $
��Left=�6    $��20��6;   $��
189,25,0,0q�6G   $
 Wrap=�6[   $��Game: ��6o   $	��Top=�6}   $	��124��6�   $��1��6�   �� 5�   
   -   5        $��btnEx��5�      # [ 6   $
��Fire��5�      $��16(�6    $��34��6.   $��34��69   $
��Left=�6E   $	��Top=�5�      $��
236,54,0,0q�6)   
�������#��[ 5�      $��1��65   $��2��6E   ��5�      �� *_Fire_Missile+5�      �� 5�   
   -   5        $��btnRight��5�      # [ 6!   $�� R    ��5�      $��16(�6"   $��Segoe WP Black)�60   $��28��5�      $��Right=�6   $��Center=�5�      $��0,56,195,64q�6,   
���   �#��[ 5�      $��1��6:   $��2��6J   ��5�      �� *_Move_Right+5�   W   �� 5�   
   -	   5        $��btnLeft��5�      # [ 6    $�� L��5�      $��16(�6   $��Segoe WP Black)�6,   $��28��5�      $��Right=�6   $��Center=�5�      $��0,56,267,64q�6,   
���   �#��[ 5�      $��1��6;   $��2��6K   ��5�      �� *
_Move_Left+5�   X   �� 5�   
   $��U��6   # [ 6   $
��Left=�6t   $��20��6�   $��
241,30,0,0q�6�   $	��Top=�6�   $��20��6�   $��1��6�   $��2��6�   $��Segoe WP Black)�6�   ��6W   �� *
_Move_Up+6�   �� 5�   
   $��D��6   # [ 6   $
��Left=�6v   $��20��6�   $��
244,92,0,0q�6�   $	��Top=�6�   $��20��6�   $��1��6�   $��2��6�   $��Segoe WP Black)�6�   ��6W   �� *
_Move_Down+6�   � 5�   
   $
��Left=�6   # [  6*   $	��400��6_   $��0,4,0,0q�6l   $	��Top=�6}   $	��500��6�   $��2��6�   $��1��6�   $��1��6�   .+�5�      �� $��1q�6   
�������$��10q�6<   ._�5�      �� # [ 6   ��6N   �� *BitmapImage+5�      �� 5�      $��1q�6   
�������$��10q�6<   ._�5�      �� # [  6   $	��100��6l   $	��100��6y   $��0,0,0,0q�6�   ��6M   �� *CameraImage+6�   5�      5�      �� 5  
   $��Clear Targets��6   # [  6)   $
��Left=�6�   $��27,5,0,0q�6�   $	��Top=�6�   $��98��6�   $��2��6�   ��6^   �� *clear_targets+6�   �� 5  
   $��Kill All Targets��6   # [  6,   $
��Left=�6�   $��	27,30,0,0q�6�   $	��Top=�6�   $��98��6�   $��2��6�   ��6a   �� *kill_all_targets+6�   �� 5  
   $��Kill All Foes��6   # [  6)   $
��Left=�6�   $��	27,55,0,0q�6�   $	��Top=�6�   $��98��6�   $��2��6�   ��6^   �� *kill_all_foes+6�   �� 5  
   $��Kill All Friends��6   # [  6,   $
��Left=�6�   $��	27,81,0,0q�6�   $	��Top=�6�   $��98��6�   $��2��6�   ��6a   �� *kill_all_friends+6�   �� 5  
   # [  6   $��Load from Server��6F   $
��Left=�6�   $��
126,13,0,0q�6�   $	��Top=�6�   $��99��6�   $��2��6�   ��6a   �� *_Show_Server_Message+6�   �� 5  
   # [  6   $��Load INI File��6F   $
��Left=�6�   $��	10,13,0,0q�6�   $	��Top=�6�   $��98��6�   ��6^   �� *_load_INI_File+6�   �� 5  
   $��Reset��6   $��1��5  
   $
��Left=�5	  
   # [ 5
  
   $��	23,79,0,0q�5  
   $��2��5  
   $	��Top=�5  
   $��75��5  
   ��5  
   �� *_Reset_Launcher+5  
   �� 5  
   $��Reload��6   $��1��5     $
��Left=�5     # [ 5     $��
403,79,0,0q�5     $��2��5     $	��Top=�5     $��75��5     ��5     �� *_Reload_Missiles+5     �� 5  
   $��1��6   $
��Left=�6"   # [ 5     $	��.01q�5      . $��14��5     $��	420,6,0,0q�6   $��2��61   $
 Wrap=�6>   $	��Top=�5     $��29��6*   $��11(�65   ��5     �� *l_phi+5  5   �� 5   
   $��1��6   $
��Left=�6"   # [ 5!     $	��.01q�5"      . $��18��5$     $��	454,6,0,0q�6   $��2��61   $
 Wrap=�6>   $	��Top=�5&     $��31��6*   $��11(�65    J� RenderTransformOrigin$ -1.15,2.167&�6C   ��5%     �� *	l_theta+5&  C   �� 5'  
   $
��Left=�6   $��23��5(     $��	21,13,0,0q�6   $
 Wrap=�61    . ���	#FFB8B8B8
���   �# [ 5,     $	��Top=�5-     $��96��6*   $��14(�65   $��Segoe UI Semilight)�6C   $��2��6c   ��5+     �� *Name+5-  c   �� 5/  
   $��1��6   # [ 6!   $��Start��6W   $��303,370,122,10q�6�   $��75��6�   $��1��6�   ��6g   ��  �� Path$ Start�6�   �� 50  
   $��1��6   $
��Stop��6!   # [ 6N   $��392,370,33,10q�6�   $��1��6�   $��75��6�   $ 	0.947,0.1&�6�   ��60   �� $
 Stop�6�   �� 51  
   $��
Take Image��6   # [  6(   $��1��52  6   $
��Left=�6F   $��
10,370,0,0q�6a   $��1��6u   $	��Top=�6�   $��75��6�   ��6   �� *Take_Picture+6�   �� 55  
   $��1��6e   $
��Left=�6u   $��	277,6,0,0q�6�   $��2��6�   $
��Wrap=�6�   $	��Top=�6�   $��36��6�   ��6   ��    GUI.launcherVars   Instance �� Source# Z $ missileCount�6�   �� 56  
   $��1��6\   $
��Left=�6l   $��	420,6,0,0q�6�   $��2��6�   $
��Wrap=�6�   $	��Top=�6�   $��36��6�   ��6   �� # Z $	 phi�6�   �� 57  
   $��1��6^   $
��Left=�6n   $��	460,6,0,0q�6�   $��2��6�   $
��Wrap=�6�   $	��Top=�6�   $��36��6�   $ 
0.75,0.815&�6�   ��6   �� # Z $ theta�6�   r� 58  
   -
   5        $��media��58      r� Source$k eC:\Users\Nick\Source\Repos\CPTS_323_Project\Production\Src\Applications\GUI\GUI\Audio\Danger_Zone.mp3?�6$     r� LoadedBehavior$
  Play=�6�   $
��Left=�6�   $��32��6�   $��	59,77,0,0q�6�   $��2��6�   $	��Top=�6�   $��81��6  $��2��6  ! � ColumnDefinitions! 59  
   �� 5:     $	��150 �6   �� 5;     $	��500 �6   �� 5<     $	��150 �6   " � RowDefinitions" 5>  
   �� 5?     $��50 �6   �� 5@     $	��400 �6   �� 5A     $	��150 �6   5D     5E     