/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 04.08.2015
 * Время: 12:59
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Linq;
using System.Linq.Expressions;

namespace LINQandWPF
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
			tmpList = new List<string>();			
		}
		
		List<string> tmpList;
		
		void BtnAdd_Click(object sender, RoutedEventArgs e)
		{
			Add();
		}	
		
		void BtnDel_Click(object sender, RoutedEventArgs e)
		{
			Del();
		}
		
		void BtnClear_Click(object sender, RoutedEventArgs e)
		{
			Clear();
		}	
		
		void BtnDes_Click(object sender, RoutedEventArgs e)
		{
			SortDescAndView();
		}
		
		void BtnAsc_Click(object sender, RoutedEventArgs e)
		{
			SortAscAndView();
		}
		
		void AddStr_KeyUp(object sender, KeyEventArgs e)
		{
			if(e.Key == Key.Enter)
				Add();
		}
		
		void window1_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.Key == Key.Enter)
			{
				if(AddStr.Text != String.Empty)				
					Add();
				else
					AddStr.Focus();					
			}
		}
		
		void BoxFilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			Filter(BoxFilter.Text);
		}
		
		void StrTreeView_KeyUp(object sender, KeyEventArgs e)
		{
			if(e.Key == Key.Delete)
				Del();
		}
		
		void View(IEnumerable<string> l)
		{
			StrTreeView.Items.Clear();
			foreach(string str in l)
				StrTreeView.Items.Add(str);				
		}	
		
		void SortDescAndView()
		{
			View(tmpList.OrderByDescending(x => x));
		}
		
		void SortAscAndView()
		{
			View(tmpList.OrderBy(x => x));			
		}
		
		void Filter (string fil)
		{			
			if(fil == String.Empty)
				View(tmpList.OrderByDescending(x => x));
			else
				View(tmpList.Where(x => x.Contains(fil)));
		}
		
		void Add()
		{
			if (AddStr.Text == String.Empty)
			{
				AddStr.Focus();
				return;
			}
			tmpList.Add(AddStr.Text);
			AddStr.Text = String.Empty;
			SortDescAndView();
			AddStr.Focus();
		}
		
		void Del()
		{
			if(StrTreeView.SelectedItem == null)
			{
				if(tmpList.Count>0)			
					tmpList.RemoveAt(tmpList.Count-1);
			}
			else
				tmpList.Remove(StrTreeView.SelectedItem.ToString());
			SortDescAndView();
		}
		
		void Clear()
		{
			tmpList.Clear();
			SortDescAndView();
		}
	}
}