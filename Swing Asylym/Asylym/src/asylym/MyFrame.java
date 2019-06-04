package asylym;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

import javax.swing.Box;
import javax.swing.DefaultComboBoxModel;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTabbedPane;
import javax.swing.JTable;
import javax.swing.JTextField;

public class MyFrame extends JFrame {

	Connection conn = null;
	PreparedStatement state = null;
	ResultSet result = null;

	int id = -1;

	JTable table = new JTable();
	JTable depTable = new JTable();
	JTable psyTable = new JTable();
	JTable searchTable = new JTable();
	JScrollPane scroller = new JScrollPane(table);
	JScrollPane depScroller = new JScrollPane(depTable);
	JScrollPane psyScroller = new JScrollPane(psyTable);
	JScrollPane searchScroller = new JScrollPane(searchTable);

	JPanel startPanel = new JPanel();

	JPanel upPanel = new JPanel();
	JPanel innerUpPanel = new JPanel();
	JPanel middleUpPanel = new JPanel();

	JPanel midPanel = new JPanel();
	JPanel upPsychologistPanel = new JPanel();
	JPanel middlePsychologistPanel = new JPanel();
	JPanel downPsychologistPanel = new JPanel();

	JPanel downUpPanel = new JPanel();
	JPanel departmentPanel = new JPanel();
	JPanel upDepartmentPanel = new JPanel();
	JPanel middleDepartmentPanel = new JPanel();
	JPanel downDepartmentPanel = new JPanel();

	JPanel searchPanel = new JPanel();
	JPanel upSearchPanel = new JPanel();
	JPanel middleSearchPanel = new JPanel();
	JPanel downSearchPanel = new JPanel();

	JTabbedPane tabbedPanel = new JTabbedPane();

	// first panel - PATIENTS
	JLabel fNameLabel = new JLabel("First Name:");
	JLabel lNameLabel = new JLabel("Last Name:");
	JLabel ageLabel = new JLabel("Age:");
	JLabel genderLabel = new JLabel("Gender: ");
	JLabel psychologistLabel = new JLabel("Psychologist: ");
	JLabel departmentLabel = new JLabel("Department: ");

	JTextField fNameTField = new JTextField();
	JTextField lNameTField = new JTextField();
	JTextField ageTField = new JTextField();
	JTextField genderTField = new JTextField();
	JTextField psychologistTField = new JTextField();
	JTextField departmentTField = new JTextField();
	JTextField searchCriteriaTField = new JTextField();

	JComboBox patientsPsychologistCombo = new JComboBox();
	JComboBox patientsDepartmentCombo = new JComboBox();

	JButton addBtn = new JButton("Add");
	JButton delBtn = new JButton("Delete");
	JButton editBtn = new JButton("Update");
	JButton showAllBtn = new JButton("Show Everything");
	JButton searchByBtn = new JButton("Search by gender");

	// second panel - PSYCHOLOGISTS
	JLabel psyFNameLabel = new JLabel("First Name:");
	JLabel psyLNameLabel = new JLabel("Last Name:");
	JLabel psySpecializationLabel = new JLabel("Specialization:");
	JLabel psySalaryLabel = new JLabel("Salary:");

	JTextField psyFNameTField = new JTextField();
	JTextField psyLNameTField = new JTextField();
	JTextField psySpecializationTField = new JTextField();
	JTextField psySalaryTField = new JTextField();

	JButton psyAddBtn = new JButton("Add");
	JButton psyDelBtn = new JButton("Delete");
	JButton psyEditBtn = new JButton("Update");
	JButton psyShowAllBtn = new JButton("Show Everything");
	JButton psySearchByBtn = new JButton("Search by specialization");
	JTextField psySearchCriteriaTField = new JTextField();

	// third panel - DEPARTMENTS
	JLabel depNameLabel = new JLabel("Name: ");
	JLabel typeLabel = new JLabel("Type:");
	JTextField depNameTField = new JTextField();
	String[] content = { "", "Psychology", "Psychiatry" };
	JComboBox<String> typeCombo = new JComboBox<>(content);

	Box box = Box.createHorizontalBox();
	JButton depAddBtn = new JButton("Add");
	JButton depDelBtn = new JButton("Delete");
	JButton depEditBtn = new JButton("Update");
	JButton depShowAllBtn = new JButton("Show Everything");
	JButton depSearchByBtn = new JButton("Search by type");
	JTextField depSearchCriteriaTField = new JTextField();

	// fourth panel - COMPLEX SEARCHING
	JLabel searchWelcomingMsg = new JLabel(
			"Here you may proceed to filter patients by their assigned psychologists and departments.");
	JLabel firstSearchLabel = new JLabel("Psychologist First Name: ");
	JTextField firstSearchTField = new JTextField();
	JLabel secondSearchLabel = new JLabel("Psychologist Second Name: ");
	JTextField secondSearchTField = new JTextField();
	JLabel thirdSearchLabel = new JLabel("Department: ");
	JTextField thirdSearchTField = new JTextField();

	JButton complexSearchBtn = new JButton("Search by psychologist and department");

	public MyFrame() {

		this.setTitle("Mental Asylym");
		this.setVisible(true);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setSize(700, 500);
		this.getContentPane().setBackground(Color.LIGHT_GRAY);
		// this.setLayout(new GridLayout(4, 1));

		JTabbedPane tp = new JTabbedPane();
		tp.setBounds(50, 50, 300, 300);
		tp.addTab("Patients", upPanel);
		tp.addTab("Psychologists", midPanel);
		tp.addTab("Departments", departmentPanel);
		tp.addTab("Complex Search", searchPanel);
		this.add(tp);

		// up panel == patients
		upPanel.setLayout(new GridLayout(3, 1));
		upPanel.setSize(590, 490);
		upPanel.add(innerUpPanel);
		innerUpPanel.setLayout(new GridLayout(6, 2));
		innerUpPanel.setSize(450, 450);
		innerUpPanel.add(fNameLabel);
		innerUpPanel.add(fNameTField);
		innerUpPanel.add(lNameLabel);
		innerUpPanel.add(lNameTField);
		innerUpPanel.add(ageLabel);
		innerUpPanel.add(ageTField);
		innerUpPanel.add(genderLabel);
		innerUpPanel.add(genderTField);
		innerUpPanel.add(psychologistLabel);
		innerUpPanel.add(patientsPsychologistCombo);
		innerUpPanel.add(departmentLabel);
		innerUpPanel.add(patientsDepartmentCombo);

		upPanel.add(middleUpPanel);
		middleUpPanel.setLayout(new GridLayout(4, 2));
		middleUpPanel.add(addBtn);
		middleUpPanel.add(delBtn);
		middleUpPanel.add(editBtn);
		middleUpPanel.add(showAllBtn);
		middleUpPanel.add(searchCriteriaTField);
		middleUpPanel.add(searchByBtn);
		addBtn.addActionListener(new AddPatientAction());
		delBtn.addActionListener(new DeletePatientAction());
		editBtn.addActionListener(new UpdatePatientAction());
		searchByBtn.addActionListener(new SearchPatientAction());
		showAllBtn.addActionListener(new ShowAllPatientsInfoAction());

		upPanel.add(downUpPanel);
		downUpPanel.add(scroller);
		scroller.setPreferredSize(new Dimension(650, 140));
		table.setModel(DBConnector.getDetailedPatientsInfoModel());
		table.addMouseListener(new MousePatientsTableAction());

		// mid panel == psychologists
		midPanel.setLayout(new GridLayout(3, 1));
		midPanel.setSize(490, 490);
		midPanel.add(upPsychologistPanel);
		upPsychologistPanel.setLayout(new GridLayout(6, 2));
		upPsychologistPanel.add(psyFNameLabel);
		upPsychologistPanel.add(psyFNameTField);
		upPsychologistPanel.add(psyLNameLabel);
		upPsychologistPanel.add(psyLNameTField);
		upPsychologistPanel.add(psySpecializationLabel);
		upPsychologistPanel.add(psySpecializationTField);
		upPsychologistPanel.add(psySalaryLabel);
		upPsychologistPanel.add(psySalaryTField);

		midPanel.add(middlePsychologistPanel);
		middlePsychologistPanel.setLayout(new GridLayout(4, 2));
		middlePsychologistPanel.add(psyAddBtn);
		middlePsychologistPanel.add(psyDelBtn);
		middlePsychologistPanel.add(psyEditBtn);
		middlePsychologistPanel.add(psyShowAllBtn);
		middlePsychologistPanel.add(psySearchCriteriaTField);
		middlePsychologistPanel.add(psySearchByBtn);
		psyAddBtn.addActionListener(new AddPsychoAction());
		psyDelBtn.addActionListener(new DeletePsychologistAction());
		psyEditBtn.addActionListener(new UpdatePsychologistAction());
		psySearchByBtn.addActionListener(new SearchPsychologistAction());
		psyShowAllBtn.addActionListener(new ShowAllPsychologistsInfoAction());

		midPanel.add(downPsychologistPanel);
		downPsychologistPanel.add(psyScroller);
		psyScroller.setPreferredSize(new Dimension(650, 140));
		psyTable.setModel(DBConnector.getAllPsychologistsModel());
		psyTable.addMouseListener(new MousePsychologistsTableAction());

		// down panel == departments
		departmentPanel.setLayout(new GridLayout(3, 1));
		departmentPanel.setSize(490, 490);
		departmentPanel.add(upDepartmentPanel);
		upDepartmentPanel.setLayout(new GridLayout(3, 2));
		upDepartmentPanel.setSize(450, 450);
		upDepartmentPanel.add(depNameLabel);
		upDepartmentPanel.add(depNameTField);
		upDepartmentPanel.add(typeLabel);
		upDepartmentPanel.add(typeCombo);

		departmentPanel.add(middleDepartmentPanel);
		middleDepartmentPanel.setLayout(new GridLayout(4, 2));
		middleDepartmentPanel.add(depAddBtn);
		middleDepartmentPanel.add(depDelBtn);
		middleDepartmentPanel.add(depEditBtn);
		middleDepartmentPanel.add(depShowAllBtn);
		middleDepartmentPanel.add(depSearchCriteriaTField);
		middleDepartmentPanel.add(depSearchByBtn);
		depAddBtn.addActionListener(new AddDepartmentAction());
		depDelBtn.addActionListener(new DeleteDepartmentAction());
		depEditBtn.addActionListener(new UpdateDepartmentAction());
		depSearchByBtn.addActionListener(new SearchDepartmentAction());
		depShowAllBtn.addActionListener(new ShowAllDepartmentsInfoAction());

		departmentPanel.add(downDepartmentPanel);
		downDepartmentPanel.add(depScroller);
		depScroller.setPreferredSize(new Dimension(650, 140));
		depTable.setModel(DBConnector.getAllDepartmentsModel());
		depTable.addMouseListener(new MouseDepartmentsTableAction());

		// search panel = Complex search
		searchPanel.setSize(490, 490);
		searchPanel.add(upSearchPanel);
		upSearchPanel.setLayout(new GridLayout(3, 1));
		upSearchPanel.setSize(450, 450);
		// upSearchPanel.add(searchWelcomingMsg);
		upSearchPanel.add(firstSearchLabel);
		upSearchPanel.add(firstSearchTField);
		upSearchPanel.add(secondSearchLabel);
		upSearchPanel.add(secondSearchTField);
		upSearchPanel.add(thirdSearchLabel);
		upSearchPanel.add(thirdSearchTField);

		searchPanel.add(middleSearchPanel);
		middleSearchPanel.add(complexSearchBtn);
		complexSearchBtn.addActionListener(new SearchResultAction());

		searchPanel.add(downSearchPanel);
		downSearchPanel.add(searchScroller);
		searchScroller.setPreferredSize(new Dimension(650, 140));
		
		generateUpdatedDepartmentsCombo();
		generateUpdatedPsychologistsCombo();

	}

	// C O M P L E X searching logic

	public MyModel searchResultsQuery(String psychologist_fname, String psychologist_lname, String department_name) {
		conn = DBConnector.getConnection();

		String sql = "select patient_fname, patient_lname, patient_gender, psychologist_fname, psychologist_lname, department_name \r\n"
				+ "from patients p join psychologists ps\r\n" + "on p.patient_id = ps.psychologist_id\r\n"
				+ "join departments d\r\n" + "on p.department_id = d.department_id\r\n"
				+ "where psychologist_fname=? \r\n" + "and psychologist_lname=?\r\n" + "and department_name=?";

		try {
			state = conn.prepareStatement(sql);
			state.setString(1, psychologist_fname);
			state.setString(2, psychologist_lname);
			state.setString(3, department_name);

			result = state.executeQuery();
			return (new MyModel(result));
		} catch (SQLException e) {
			e.printStackTrace();
		} catch (Exception e) {
			e.printStackTrace();
		}

		return null;
	}

	class SearchResultAction implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent arg0) {

			String searchedPsychologistFName = firstSearchTField.getText();
			String searchedPsychologistLName = secondSearchTField.getText();
			String searchedDepartment = thirdSearchTField.getText();

			try {
				clearSearchForm();
				searchTable.setModel(
						searchResultsQuery(searchedPsychologistFName, searchedPsychologistLName, searchedDepartment));
				id = 0;
			} catch (Exception e1) {
				e1.printStackTrace();
			}

			/*
			 * name/family attempt String searchedDepartment =
			 * firstSearchTField.getText(); String searchedPsychologist =
			 * secondSearchTField.getText(); String searchedFName =
			 * searchedPsychologist.substring(0, searchedPsychologist.indexOf(" ")); String
			 * searchedLName =
			 * searchedPsychologist.substring(searchedPsychologist.indexOf(" ") + 1);
			 * 
			 * try { clearSearchForm();
			 * searchTable.setModel(searchResultsQuery(searchedFName, searchedLName,
			 * searchedDepartment)); id = 0;
			 * 
			 * } catch (Exception e1) { e1.printStackTrace(); }
			 */
		}

	}

	// P A T I E N T S logic

	class ShowAllPatientsInfoAction implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO Auto-generated method stub
			conn = DBConnector.getConnection();
			String sql = "select * from patients";
			try {
				state = conn.prepareStatement(sql);
				state.execute();
				table.setModel(DBConnector.getDetailedPatientsInfoModel());
			} catch (SQLException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			} finally {
				try {
					state.close();
					conn.close();
				} catch (SQLException e1) {
					e1.printStackTrace();
				}
			}
		}
	}

	public MyModel searchPatientByGenderModel(String parameter) {
		String sql = "select * from patients where patient_gender=?";
		conn = DBConnector.getConnection();
		try {
			PreparedStatement state = conn.prepareStatement(sql);
			state.setString(1, parameter);
			result = state.executeQuery();
			return new MyModel(result);
		} catch (SQLException e) {
			e.printStackTrace();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return null;
	}

	class SearchPatientAction implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {

			String searchRequest = searchCriteriaTField.getText();

			try {
				clearPatientsForm();
				table.setModel(searchPatientByGenderModel(searchRequest));
				searchCriteriaTField.setText("");
				id = 0;
			} catch (Exception e1) {
				e1.printStackTrace();
			}

		}
	}

	class UpdatePatientAction implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {

			String psychologistCombo = (patientsPsychologistCombo.getSelectedItem()).toString();
			String departmentCombo = (patientsDepartmentCombo.getSelectedItem()).toString();
			String fname = fNameTField.getText();
			String lname = lNameTField.getText();
			int age = Integer.parseInt(ageTField.getText());
			String gender = genderTField.getText();
			int psychologistId = Integer.parseInt(psychologistCombo.substring(0, psychologistCombo.indexOf('.')));
			int departmentId = Integer.parseInt(departmentCombo.substring(0, departmentCombo.indexOf('.')));

			conn = DBConnector.getConnection();
			String sql = "update patients set "
					+ "patient_fname=?, patient_lname=?, patient_age=?, patient_gender=?, psychologist_id=?, department_id=?"
					+ "where patient_id=?";
			try {
				state = conn.prepareStatement(sql);
				state = conn.prepareStatement(sql);
				state.setString(1, fname);
				state.setString(2, lname);
				state.setInt(3, age);
				state.setString(4, gender);
				state.setInt(5, psychologistId);
				state.setInt(6, departmentId);
				state.setInt(7, id);
				state.execute();

				clearPatientsForm();

				table.setModel(DBConnector.getDetailedPatientsInfoModel());
				id = 0;

			} catch (SQLException e1) {
				e1.printStackTrace();
			}
		}
	}

	class DeletePatientAction implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {

			conn = DBConnector.getConnection();
			String sql = "delete from patients where patient_id=?";
			try {
				state = conn.prepareStatement(sql);
				state.setInt(1, id);
				state.execute();
				clearPatientsForm();
				table.setModel(DBConnector.getDetailedPatientsInfoModel());
			} catch (SQLException e1) {
				e1.printStackTrace();
			}
		}

	}

	class MousePatientsTableAction implements MouseListener {

		@Override
		public void mouseClicked(MouseEvent e) {
			int row = table.getSelectedRow();
			Object cellValue = table.getValueAt(row, 0);
			id = Integer.parseInt(cellValue.toString());

			if (e.getClickCount() > 1) {
				fNameTField.setText(table.getValueAt(row, 1).toString());
				lNameTField.setText(table.getValueAt(row, 2).toString());
				ageTField.setText(table.getValueAt(row, 3).toString());
				genderTField.setText(table.getValueAt(row, 4).toString());
				

				String psychologistFullName = table.getValueAt(row, 5).toString() + " "
						+ table.getValueAt(row, 6).toString();
				String departmentName = table.getValueAt(row, 7).toString();

				for (int i = 0; i < patientsPsychologistCombo.getItemCount(); i++) {
					String currentItem = patientsPsychologistCombo.getItemAt(i).toString();
					String currentItemName = currentItem.substring(currentItem.indexOf('.') + 1);

					if (currentItemName.equals(psychologistFullName)) {
						patientsPsychologistCombo.setSelectedIndex(i);
					}
				}

				for (int i = 0; i < patientsDepartmentCombo.getItemCount(); i++) {
					String currentItem = patientsDepartmentCombo.getItemAt(i).toString();
					String currentItemName = currentItem.substring(currentItem.indexOf('.') + 1);

					if (currentItemName.equals(departmentName)) {
						patientsDepartmentCombo.setSelectedIndex(i);
					}
				}
			}
		}

		@Override
		public void mouseEntered(MouseEvent arg0) {
		}

		@Override
		public void mouseExited(MouseEvent arg0) {
		}

		@Override
		public void mousePressed(MouseEvent arg0) {
		}

		@Override
		public void mouseReleased(MouseEvent arg0) {
		}
	}

	class AddPatientAction implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			
			String psychologistCombo = (patientsPsychologistCombo.getSelectedItem()).toString();
			String departmentCombo = (patientsDepartmentCombo.getSelectedItem()).toString();
			String fname = fNameTField.getText();
			String lname = lNameTField.getText();
			int age = Integer.parseInt(ageTField.getText());
			String gender = genderTField.getText();
			int psychologistId = Integer.parseInt(psychologistCombo.substring(0, psychologistCombo.indexOf('.')));
			int departmentId = Integer.parseInt(departmentCombo.substring(0, departmentCombo.indexOf('.')));

			String sql = "insert into patients values(null,?,?,?,?,?,?);";
			conn = DBConnector.getConnection();

			try {
				state = conn.prepareStatement(sql);
				state.setString(1, fname);
				state.setString(2, lname);
				state.setInt(3, age);
				state.setString(4, gender);
				state.setInt(5, psychologistId);
				state.setInt(6, departmentId);

				state.execute();

				clearPatientsForm();

				table.setModel(DBConnector.getDetailedPatientsInfoModel());
				//table.setModel(DBConnector.getAllPatientsModel());
				id = 0;
			} catch (SQLException e1) {
				e1.printStackTrace();
			}
		}

	}

	// P S Y C H O L O G I S T S logic

	class ShowAllPsychologistsInfoAction implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO Auto-generated method stub
			conn = DBConnector.getConnection();
			String sql = "select * from psychologists";
			try {
				state = conn.prepareStatement(sql);
				state.execute();
				psyTable.setModel(DBConnector.getAllPsychologistsModel()); //
			} catch (SQLException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			} finally {
				try {
					state.close();
					conn.close();
				} catch (SQLException e1) {
					e1.printStackTrace();
				}
			}
		}
	}

	public MyModel searchPsychologistsDBModel(String parameter) {
		String sql = "select * from psychologists where psychologist_spec=?";
		conn = DBConnector.getConnection();
		try {
			PreparedStatement state = conn.prepareStatement(sql);
			state.setString(1, parameter);
			result = state.executeQuery();
			return new MyModel(result);
		} catch (SQLException e) {
			e.printStackTrace();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return null;
	}

	class SearchPsychologistAction implements ActionListener {
		@Override
		public void actionPerformed(ActionEvent e) {

			String searchRequest = psySearchCriteriaTField.getText();

			try {
				clearPsychologistsForm();
				psyTable.setModel(searchPsychologistsDBModel(searchRequest));
				psySearchCriteriaTField.setText("");
				id = 0;

			} catch (Exception e1) {
				e1.printStackTrace();
			}

		}
	}

	class MousePsychologistsTableAction implements MouseListener {

		@Override
		public void mouseClicked(MouseEvent e) {

			int row = psyTable.getSelectedRow();
			Object cellValue = psyTable.getValueAt(row, 0);
			id = Integer.parseInt(cellValue.toString());

			if (e.getClickCount() > 1) {
				psyFNameTField.setText(psyTable.getValueAt(row, 1).toString());
				psyLNameTField.setText(psyTable.getValueAt(row, 2).toString());
				psySpecializationTField.setText(psyTable.getValueAt(row, 3).toString());
				psySalaryTField.setText(psyTable.getValueAt(row, 4).toString());
			}
		}

		@Override
		public void mouseEntered(MouseEvent arg0) {
		}

		@Override
		public void mouseExited(MouseEvent arg0) {
		}

		@Override
		public void mousePressed(MouseEvent arg0) {
		}

		@Override
		public void mouseReleased(MouseEvent arg0) {
		}
	}

	class UpdatePsychologistAction implements ActionListener {
		@Override
		public void actionPerformed(ActionEvent e) {

			String psychologistFName = psyFNameTField.getText();
			String psychologistLName = psyLNameTField.getText();
			String psychologistSpec = psySpecializationTField.getText();
			float psychologistSalary = Float.parseFloat(psySalaryTField.getText());

			conn = DBConnector.getConnection();

			String sql = "update psychologists set "
					+ "psychologist_fname=?, psychologist_lname=?, psychologist_spec=?, psychologist_salary=?"
					+ "where psychologist_id=?";
			try {
				state = conn.prepareStatement(sql);
				state = conn.prepareStatement(sql);
				state.setString(1, psychologistFName);
				state.setString(2, psychologistLName);
				state.setString(3, psychologistSpec);
				state.setFloat(4, psychologistSalary);
				state.setInt(5, id);
				state.execute();

				clearPsychologistsForm();
				psyTable.setModel(DBConnector.getAllPsychologistsModel());
				id = 0;

			} catch (SQLException e1) {
				e1.printStackTrace();
			}

			generateUpdatedPsychologistsCombo();
		}
	}

	class DeletePsychologistAction implements ActionListener {
		@Override
		public void actionPerformed(ActionEvent e) {

			String sql = "delete from psychologists where psychologist_id=?";

			conn = DBConnector.getConnection();
			try {
				state = conn.prepareStatement(sql);
				state.setInt(1, id);
				state.execute();
				id = -1;
				psyTable.setModel(DBConnector.getAllPsychologistsModel());
			} catch (SQLException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}
			
			generateUpdatedPsychologistsCombo();
		}

	}

	class AddPsychoAction implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {

			String psychologistFName = psyFNameTField.getText();
			String psychologistLName = psyLNameTField.getText();
			String psychologistSpec = psySpecializationTField.getText();
			float psychologistSalary = Float.parseFloat(psySalaryTField.getText());

			String sql = "insert into psychologists values(null,?,?,?,?);";

			conn = DBConnector.getConnection();

			try {
				state = conn.prepareStatement(sql);
				state.setString(1, psychologistFName);
				state.setString(2, psychologistLName);
				state.setString(3, psychologistSpec);
				state.setFloat(4, psychologistSalary);
				state.execute();
				psyTable.setModel(DBConnector.getAllPsychologistsModel()); 
			} catch (SQLException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			} finally {
				try {
					state.close();
					conn.close();
				} catch (SQLException e1) {
					e1.printStackTrace();
				}
			}
			generateUpdatedPsychologistsCombo();
			clearPsychologistsForm();
		}
	}

	// D E P A R T M E N T S logic

	class ShowAllDepartmentsInfoAction implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO Auto-generated method stub
			conn = DBConnector.getConnection();
			String sql = "select * from departments";
			try {
				state = conn.prepareStatement(sql);
				state.execute();
				depTable.setModel(DBConnector.getAllDepartmentsModel()); 
			} catch (SQLException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			} finally {
				try {
					state.close();
					conn.close();
				} catch (SQLException e1) {
					e1.printStackTrace();
				}
			}
		}
	}

	public MyModel searchDepartmentsByTypeDBModel(String parameter) {
		String sql = "select * from departments where department_type=?";
		conn = DBConnector.getConnection();
		try {
			PreparedStatement state = conn.prepareStatement(sql);
			state.setString(1, parameter);
			result = state.executeQuery();
			return new MyModel(result);
		} catch (SQLException e) {
			e.printStackTrace();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return null;
	}

	class SearchDepartmentAction implements ActionListener {
		@Override
		public void actionPerformed(ActionEvent e) {

			String searchRequest = depSearchCriteriaTField.getText();

			try {
				clearDepartmentsForm();
				depTable.setModel(searchDepartmentsByTypeDBModel(searchRequest));
				depSearchCriteriaTField.setText("");
				
				id = 0;

			} catch (Exception e1) {
				e1.printStackTrace();
			}

		}
	}

	class UpdateDepartmentAction implements ActionListener {
		@Override
		public void actionPerformed(ActionEvent e) {

			String departmentName = depNameTField.getText();
			String departmentType = typeCombo.getSelectedItem().toString();

			conn = DBConnector.getConnection();

			String sql = "update departments set " + "department_name=?, department_type=?" + "where department_id=?";
			try {
				state = conn.prepareStatement(sql);
				state = conn.prepareStatement(sql);
				state.setString(1, departmentName);
				state.setString(2, departmentType);
				state.setInt(3, id);
				state.execute();

				clearDepartmentsForm();
				depTable.setModel(DBConnector.getAllDepartmentsModel());
				id = 0;

			} catch (SQLException e1) {
				e1.printStackTrace();
			}

			generateUpdatedDepartmentsCombo();
		}
	}

	class DeleteDepartmentAction implements ActionListener {
		@Override
		public void actionPerformed(ActionEvent e) {

			String sql = "delete from departments where department_id=?";
			conn = DBConnector.getConnection();
			try {
				state = conn.prepareStatement(sql);
				state.setInt(1, id);
				state.execute();
				id = -1;
				depTable.setModel(DBConnector.getAllDepartmentsModel());
			} catch (SQLException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}
			
			generateUpdatedDepartmentsCombo();
		}

	}

	class MouseDepartmentsTableAction implements MouseListener {

		@Override
		public void mouseClicked(MouseEvent e) {
			// TODO Auto-generated method stub

			int row = depTable.getSelectedRow();
			id = Integer.parseInt(depTable.getValueAt(row, 0).toString());

			if (e.getClickCount() > 1) {
				depNameTField.setText(depTable.getValueAt(row, 1).toString());
				typeCombo.setSelectedItem(depTable.getValueAt(row, 2).toString());
			}

		}

		@Override
		public void mouseEntered(MouseEvent arg0) {
			// TODO Auto-generated method stub

		}

		@Override
		public void mouseExited(MouseEvent arg0) {
			// TODO Auto-generated method stub

		}

		@Override
		public void mousePressed(MouseEvent arg0) {
			// TODO Auto-generated method stub

		}

		@Override
		public void mouseReleased(MouseEvent arg0) {
			// TODO Auto-generated method stub

		}

	}

	class AddDepartmentAction implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {

			Object source = e.getSource();

			if (source == depAddBtn) {

				String departmentName = depNameTField.getText();
				String departmentType = typeCombo.getSelectedItem().toString();

				
				String sql = "insert into departments values(null,?,?);";

				conn = DBConnector.getConnection();

				try {
					state = conn.prepareStatement(sql);
					state.setString(1, departmentName);
					state.setString(2, departmentType);
					state.execute();
					depTable.setModel(DBConnector.getAllDepartmentsModel()); 
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				} finally {
					try {
						state.close();
						conn.close();
					} catch (SQLException e1) {
						e1.printStackTrace();
					}
				}

				generateUpdatedDepartmentsCombo();
				clearDepartmentsForm();

			}
		}
	}

	// clearing forms methods
	private void clearSearchForm() {
		firstSearchTField.setText("");
		secondSearchTField.setText("");
		thirdSearchTField.setText("");
	}

	private void clearPatientsForm() {
		fNameTField.setText("");
		lNameTField.setText("");
		ageTField.setText("");
		genderTField.setText("");
		psychologistTField.setText("");
		departmentTField.setText("");
		patientsPsychologistCombo.setSelectedIndex(0);
		patientsDepartmentCombo.setSelectedIndex(0);
	}

	private void clearPsychologistsForm() {
		psyFNameTField.setText("");
		psyLNameTField.setText("");
		psySpecializationTField.setText("");
		psySalaryTField.setText("");
	}

	private void clearDepartmentsForm() {
		depNameTField.setText("");
		typeCombo.setSelectedIndex(0);
	}

	// generating updated info for combo boxes
	public void generateUpdatedPsychologistsCombo() {

		ArrayList<String> psychologistComboArray = new ArrayList<>();
		String psychologistComboStr = null;

		conn = DBConnector.getConnection();
		String sql = "select * from psychologists";

		try {
			state = conn.prepareStatement(sql);
			result = state.executeQuery();
		} catch (SQLException e) {
			e.printStackTrace();
		} catch (Exception e) {
			e.printStackTrace();
		}

		{
			try {
				while (result.next()) {
					psychologistComboStr = result.getObject(1) + "." + result.getObject(2) + " " + result.getObject(3);
					psychologistComboArray.add(psychologistComboStr);
				}
			} catch (Exception e) {
			}
		}

		patientsPsychologistCombo.setModel(new DefaultComboBoxModel(psychologistComboArray.toArray()));

	}

	public void generateUpdatedDepartmentsCombo() {
		ArrayList<String> departmentComboArray = new ArrayList<>();
		String departmentComboString = null;

		conn = DBConnector.getConnection();
		String sql = "select * from departments";

		try {
			state = conn.prepareStatement(sql);
			result = state.executeQuery();
		} catch (SQLException e) {
			e.printStackTrace();
		} catch (Exception e) {
			e.printStackTrace();
		}

		{
			try {
				while (result.next()) {
					departmentComboString = result.getObject(1) + "." + result.getObject(2);
					departmentComboArray.add(departmentComboString.toString());
				}
			} catch (Exception e) {
			}
		}

		patientsDepartmentCombo.setModel(new DefaultComboBoxModel(departmentComboArray.toArray()));

	}
}
