   M S B A M L   `   `   `  ����B  >WpfAuth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfAuth.ViewWpfAuth.View  5   	       WpfAuth.View.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfAuth.View     5   	     � Title$  LoginWindow��5   	   $	��450��6   $	��800��6*   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��80 �6   .+�5   
   �� $��	Username:��6   $��0��6%   $��0��62   �� 5   
   $��	Password:��6   $��1��6%   $��0��62   �� 5   
   $��0��6,   $��1��69   ��6   �� *
Username+69   G� 5   
   -   5         G�Name$ passwordBox��5      $��1��6+   $��1��68   �� 5   
    �� Orientation$ 
Horizontal=�6   $��2��6.   $��2��6;   .+�5      �� $��Log in��6   $��Center=�5      ��5   &   �� *LoginCommand+ �� Mode$ OneTime=���5      ��  �� ElementName$ passwordBox��5      5      5      5      