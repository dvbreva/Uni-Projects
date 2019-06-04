package asylym;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;


public class DBConnector {
	
	static Connection conn = null;
	static ResultSet result = null;
	static MyModel model = null;
	
	public static Connection getConnection() {
		
		try {
			Class.forName("org.h2.Driver");
			conn = DriverManager.getConnection("jdbc:h2:tcp://localhost/D:/Users/user/Desktop/desktop 3", "sa", "");
		} catch (ClassNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return conn;
	}
	
	public static MyModel getAllDepartmentsModel() {
		String sql = "select * from departments";
		conn = getConnection();
		try {
			PreparedStatement state = conn.prepareStatement(sql);
			result = state.executeQuery();
			model = new MyModel(result);
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return model;
	}//end method
	
	public static MyModel getAllPsychologistsModel() {
		String sql = "select * from psychologists";
		conn = getConnection();
		try {
			PreparedStatement state = conn.prepareStatement(sql);
			result = state.executeQuery();
			model = new MyModel(result);
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		return model;
	}//end method
	
	public static MyModel getAllPatientsModel() {
		String sql = "select * from patients";
		conn = getConnection();
		try {
			PreparedStatement state = conn.prepareStatement(sql);
			result = state.executeQuery();
			model = new MyModel(result);
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		return model;
	}//end method
	
	public static MyModel getDetailedPatientsInfoModel() {
		String sql = "select patient_id, patient_fname, patient_lname, patient_age, patient_gender, psychologist_fname, psychologist_lname, department_name\r\n" + 
		             "from patients pa join psychologists ps\r\n" + 
				     "on pa.psychologist_id = ps.psychologist_id\r\n" + 
				     "join departments d\r\n" + 
				     "on pa.department_id = d.department_id ";
		conn = getConnection();
		try {
			PreparedStatement state = conn.prepareStatement(sql);
			result = state.executeQuery();
			model = new MyModel(result);
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		return model;
	}//end method
	
	

}
