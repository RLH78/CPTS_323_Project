   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI  5   	       GUI.LauncherSelect   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   !guiclr-namespace:GUI     5   	   -   5        $��LauncherSelectName��5   9     � Title$  LauncherSelect��6	   $	��300��6    $	��300��6-    � 	Resources 5         GUI.launcherViewModel   launcherModel��%   &	          5   
   6    5	      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    � MappingMode$ RelativeToBoundingBox=�63    �� 
StartPoint$ 0.5,0&�6W   .��5      �  � Color$
 Aqua��6   � 5      $ 	#FF01FFE8��6    � Offset$ 0.127Q�61   � 5      $ 	#FF35B5FF��6   $ 0.868Q�61   5      .+�5   
   	� -   5         	�Name$ Mock_Launcher��5   x    � DataContext# [  6   $
��Mock��6�   $
��Left=�6�   $��21��6�   $��
75,167,0,0q�6�   $	��Top=�6�   $	��157��6�   $��18(�6�   $��RightToLeft=�6  ��6O   �� *_create_Mock_Command+6  	� 5   
   -   5        $ Dream_Cheeky��5   v   # [  6   $��DreamCheeky��6�   $
��Left=�6�   $��28��6�   $��
76,212,0,0q�6�   $	��Top=�6�   $	��156��6�   $��18(�6  $��RightToLeft=�6  ��6O   �� *_create_DC_Command+6  �� 5   
   $��Select a launcher type:��6   $��Center=�62   $��39��6O   $��28,123,28,0q�6[   $	��Top=�6p   $	��236��6�   $��20(�6�   $
��Bold"�6�   �� 5   
   $��Enter a Team Name:��6   $��Center=�6-   $��39��6J   $��
28,20,28,0q�6V   $	��Top=�6j   $	��236��6�   $��20(�6�   $
��Bold"�6�   �� 5   
   $
��Left=�6   # [  6-   $��23��5      $��	28,74,0,0q�6   	 �� TextWrapping$
	 Wrap=�61   $	��Top=�6[   $	��145��6s   $��Center=�6   ��6E   �� *Name+6   �� 5   
   $
��Okay��6   ���	#FF00C1D4# [  67   $
��Left=�6�   $��
188,74,0,0q�6�   $	��Top=�6�   $��44��6�   $��23��6�   ��6p   �� *_change_Team_Name+6�   �� 5   
   $
��Left=�6   $��
28,102,0,0q�6/   $
��Wrap=�6C   # [  6W   $	��Top=�6�   $	��145��6�   ��6�   �� *settingMessage+6�   5       5!      