   M S B A M L   `   `   `  ����  BookStoreGUI    BookStoreGUI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  F21's BookStore��5   	   $	��500��6!   $	��550��6.   .��5      � $��0,0,0,-8q�6   .+�5   
   �� $��Bottom=�6   $��Stretch=�6/   $��0,0,0,10q�6M   .@�5      �� -   5         ��Name$ statusTextBlock��5      �� 62   $1�+Please login before proceeding to checkout.��66   6l   5      �� 5	   
   -   5         ��Name$ 
LayoutRoot��5	       �� Orientation$ Vertical=�6A   $
��Left=�6X   $
��auto��6s   $	��532��6�    � DataContext 6)   �� .+�5
      �� $ 
Horizontal=�6   $
��Left=�62   .+�5      �� $��Categories:��6   $��18,0,0,0q�6.   �� 5      -   5         ��Name$ categoriesComboBox��5   3   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5       �� DisplayMemberPath$
 Name��5      $��23��6    $��12q�6,   $	��200��68   ��5      �� ��5      �� 5      .R�5      $� 5      5      �� 5      -   5         ��Name$ loginButton��5   5   $��Login��6   $��25��6)   $��75��6J   $��28,2,0,0q�6U   6g   �� 5      -   5        $ 
exitButton��5   4   $
��Exit��6   $��25��6(   $��75��6H   $��20,2,0,0q�6S   6e   5      &   System.Windows.Controls.DataGrid  5      -   5        	  Name$	 ProductsDataGrid��5      
   AutoGenerateColumns
 .  $	��165��5   3      RowDetailsVisibilityMode$ VisibleWhenSelected=�5      $	��490��5      $
��Left=�6   $��
20,0,20,10q�6*      SelectionMode$ Single=�5      ��5      �� *
drCat_Book+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        titleColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Title��5          Width5  /System.Windows.Controls.DataGridLengthConverter$	 50* 6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5      �� *Title+5         5!      -	   5        authorColumn��$ Author��5#      $	 18* 6    5"      �� *Author+5#        5$      -
   5        priceColumn��$ Price��5&      $	 12* 6      CanUserSort .   5%      �� *Price+5&        5'      -   5        
yearColumn��$
 Year��5)      $ 8* 6    5(      �� *Year+5)      5+      �� 5,      $ Vertical=�6   .+�5-      �� -   5         ��Name$ orderListView��5-      $	��150��62   $	��490��6B    �� SelectionMode$ Single=�5.      ��6   ��  �� View 5/      �� 50      .P�51      ��  �� Width$ 80��6-   $
��ISBN��68    �� DisplayMemberBinding 52      �� *BookID+�� 53      $	 285��6-   $��Title��69    54      �� *	BookTitle+�� 55      $ 60��6-   $��Quantity��68    56      �� *
Quantity+�� 57      $ 60��6-   $��Subtotal��68    58      �� *
SubTotal+59      5;      5<      �� 5=      -   5        $ 	myAccount��5=      $��25��6(   $��80��67   $��
My Account��6E   $��	380,0,0,0q�6w   $	��108��6�   �� 5>      $ 
Horizontal=�6   $��Center=�62   $��10, 10, 10, 10q�6O   $��26��6g   $	��511��6s    J� RenderTransformOrigin$ 0.498,-0.073&�6   z�5?      V� 5@      .~�5A      �� �� 5B      �� 5C      T� 5D       T� Y$ -6Q�6-   5E      .+�5H      �� -   5        $ 	addButton��5H      $��25��6,   $��80��6;   $��Add Book��6I   6\   �� 5I      -   5        $ removeButton��5I      $��25��6/   $��80��6>   $��Remove Book��6L   $��10,0,0,0q�6}   �� 5J      -   5        $ calculateBtn��5J      $��Calculate Total��6/   $��25��6I   $��80��6X   $��20,0,0,0q�6g   6y   �� 5K      $��Total ��6   $��20,0,0,0q�6)   �� 5L      -   5         ��Name$ txtTotal��5L      $��22��6,    �� TextWrapping$
 Wrap=�68   $��0��6L   $��59��6U    �� SelectionOpacity$ 0Q�6v   ��6`   Z� 6v   �� 5N      -   5        $ checkoutOrderButton��5N      $��25��66   $��80��6E   $��Proceed to Checkout��6S   $	��121��6�   $��0,0,0,0q�6�   5O      5P      5Q      5R      