using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CryptoLadder.Model {
    /// <summary>
    /// Place new order response
    /// </summary>
    [DataContract]
    public partial class OrderRes : IEquatable<OrderRes>, IValidatableObject {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRes" /> class.
        /// </summary>
        public OrderRes()
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRes" /> class.
        /// </summary>
        /// <param name="orderId">orderId.</param>
        /// <param name="userId">userId.</param>
        /// <param name="symbol">symbol.</param>
        /// <param name="side">side.</param>
        /// <param name="orderType">orderType.</param>
        /// <param name="price">price.</param>
        /// <param name="qty">qty.</param>
        /// <param name="timeInForce">timeInForce.</param>
        /// <param name="orderStatus">orderStatus.</param>
        /// <param name="lastExecTime">lastExecTime.</param>
        /// <param name="lastExecPrice">lastExecPrice.</param>
        /// <param name="leavesQty">leavesQty.</param>
        /// <param name="cumExecQty">cumExecQty.</param>
        /// <param name="cumExecValue">cumExecValue.</param>
        /// <param name="cumExecFee">cumExecFee.</param>
        /// <param name="rejectReason">rejectReason.</param>
        /// <param name="orderLinkId">orderLinkId.</param>
        /// <param name="createdAt">createdAt.</param>
        /// <param name="updatedAt">updatedAt.</param>
        public OrderRes (string orderId = default (string), decimal? userId = default (decimal?), string symbol = default (string), string side = default (string), string orderType = default (string), double? price = default (double?), int qty = default (int), string timeInForce = default (string), string orderStatus = default (string), double? lastExecTime = default (double?), double? lastExecPrice = default (double?), decimal? leavesQty = default (decimal?), decimal? cumExecQty = default (decimal?), decimal? cumExecValue = default (decimal?), double? cumExecFee = default (double?), string rejectReason = default (string), string orderLinkId = default (string), string createdAt = default (string), string updatedAt = default (string)) {
            this.OrderId = orderId;
            this.UserId = userId;
            this.Symbol = symbol;
            this.Side = side;
            this.OrderType = orderType;
            this.Price = price;
            this.Qty = qty;
            this.TimeInForce = timeInForce;
            this.OrderStatus = orderStatus;
            this.LastExecTime = lastExecTime;
            this.LastExecPrice = lastExecPrice;
            this.LeavesQty = leavesQty;
            this.CumExecQty = cumExecQty;
            this.CumExecValue = cumExecValue;
            this.CumExecFee = cumExecFee;
            this.RejectReason = rejectReason;
            this.OrderLinkId = orderLinkId;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

        /// <summary>
        /// Gets or Sets OrderId
        /// </summary>
        [JsonPropertyName("order_id")]
        [DataMember (Name = "order_id", EmitDefaultValue = false)]
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or Sets UserId
        /// </summary>
        [JsonPropertyName("user_id")]
        [DataMember (Name = "user_id", EmitDefaultValue = false)]
        public decimal? UserId { get; set; }

        /// <summary>
        /// Gets or Sets Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        [DataMember (Name = "symbol", EmitDefaultValue = false)]
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or Sets Side
        /// </summary>
        [JsonPropertyName("side")]
        [DataMember (Name = "side", EmitDefaultValue = false)]
        public string Side { get; set; }

        /// <summary>
        /// Gets or Sets OrderType
        /// </summary>
        [JsonPropertyName("order_type")]
        [DataMember (Name = "order_type", EmitDefaultValue = false)]
        public string OrderType { get; set; }

        /// <summary>
        /// Gets or Sets Price
        /// </summary>
        [JsonPropertyName("price")]
        [DataMember (Name = "price", EmitDefaultValue = false)]
        public double? Price { get; set; }

        /// <summary>
        /// Gets or Sets Qty
        /// </summary>
        [JsonPropertyName("qty")]
        [DataMember (Name = "qty", EmitDefaultValue = false)]
        public int Qty { get; set; }

        /// <summary>
        /// Gets or Sets TimeInForce
        /// </summary>
        [JsonPropertyName("time_in_force")]
        [DataMember (Name = "time_in_force", EmitDefaultValue = false)]
        public string TimeInForce { get; set; }

        /// <summary>
        /// Gets or Sets OrderStatus
        /// </summary>
        [JsonPropertyName("order_status")]
        [DataMember (Name = "order_status", EmitDefaultValue = false)]
        public string OrderStatus { get; set; }

        /// <summary>
        /// Gets or Sets LastExecTime
        /// </summary>
        [JsonPropertyName("last_exec_time")]
        [DataMember (Name = "last_exec_time", EmitDefaultValue = false)]
        public double? LastExecTime { get; set; }

        /// <summary>
        /// Gets or Sets LastExecPrice
        /// </summary>
        [JsonPropertyName("last_exec_price")]
        [DataMember (Name = "last_exec_price", EmitDefaultValue = false)]
        public double? LastExecPrice { get; set; }

        /// <summary>
        /// Gets or Sets LeavesQty
        /// </summary>
        [JsonPropertyName("leaves_qty")]
        [DataMember (Name = "leaves_qty", EmitDefaultValue = false)]
        public decimal? LeavesQty { get; set; }

        /// <summary>
        /// Gets or Sets CumExecQty
        /// </summary>
        [JsonPropertyName("cum_exec_qty")]
        [DataMember (Name = "cum_exec_qty", EmitDefaultValue = false)]
        public decimal? CumExecQty { get; set; }

        /// <summary>
        /// Gets or Sets CumExecValue
        /// </summary>
        [JsonPropertyName("cum_exec_value")]
        [DataMember (Name = "cum_exec_value", EmitDefaultValue = false)]
        public decimal? CumExecValue { get; set; }

        /// <summary>
        /// Gets or Sets CumExecFee
        /// </summary>
        [JsonPropertyName("cum_exec_fee")]
        [DataMember (Name = "cum_exec_fee", EmitDefaultValue = false)]
        public double? CumExecFee { get; set; }

        /// <summary>
        /// Gets or Sets RejectReason
        /// </summary>
        [JsonPropertyName("reject_reason")]
        [DataMember (Name = "reject_reason", EmitDefaultValue = false)]
        public string RejectReason { get; set; }

        /// <summary>
        /// Gets or Sets OrderLinkId
        /// </summary>
        [JsonPropertyName("order_link_id")]
        [DataMember (Name = "order_link_id", EmitDefaultValue = false)]
        public string OrderLinkId { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [JsonPropertyName("created_at")]
        [DataMember (Name = "created_at", EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        [JsonPropertyName("updated_at")]
        [DataMember (Name = "updated_at", EmitDefaultValue = false)]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString () {
            var sb = new StringBuilder ();
            sb.Append ("class OrderRes {\n");
            sb.Append ("  OrderId: ").Append (OrderId).Append ("\n");
            sb.Append ("  UserId: ").Append (UserId).Append ("\n");
            sb.Append ("  Symbol: ").Append (Symbol).Append ("\n");
            sb.Append ("  Side: ").Append (Side).Append ("\n");
            sb.Append ("  OrderType: ").Append (OrderType).Append ("\n");
            sb.Append ("  Price: ").Append (Price).Append ("\n");
            sb.Append ("  Qty: ").Append (Qty).Append ("\n");
            sb.Append ("  TimeInForce: ").Append (TimeInForce).Append ("\n");
            sb.Append ("  OrderStatus: ").Append (OrderStatus).Append ("\n");
            sb.Append ("  LastExecTime: ").Append (LastExecTime).Append ("\n");
            sb.Append ("  LastExecPrice: ").Append (LastExecPrice).Append ("\n");
            sb.Append ("  LeavesQty: ").Append (LeavesQty).Append ("\n");
            sb.Append ("  CumExecQty: ").Append (CumExecQty).Append ("\n");
            sb.Append ("  CumExecValue: ").Append (CumExecValue).Append ("\n");
            sb.Append ("  CumExecFee: ").Append (CumExecFee).Append ("\n");
            sb.Append ("  RejectReason: ").Append (RejectReason).Append ("\n");
            sb.Append ("  OrderLinkId: ").Append (OrderLinkId).Append ("\n");
            sb.Append ("  CreatedAt: ").Append (CreatedAt).Append ("\n");
            sb.Append ("  UpdatedAt: ").Append (UpdatedAt).Append ("\n");
            sb.Append ("}\n");
            return sb.ToString ();
        }
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return JsonSerializer.Serialize(this, options);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals (object input) {
            return this.Equals (input as OrderRes);
        }

        /// <summary>
        /// Returns true if OrderRes instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderRes to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals (OrderRes input) {
            if (input == null)
                return false;

            return (
                this.OrderId == input.OrderId ||
                (this.OrderId != null &&
                    this.OrderId.Equals (input.OrderId))
            ) &&
            (
                this.UserId == input.UserId ||
                (this.UserId != null &&
                    this.UserId.Equals (input.UserId))
            ) &&
            (
                this.Symbol == input.Symbol ||
                (this.Symbol != null &&
                    this.Symbol.Equals (input.Symbol))
            ) &&
            (
                this.Side == input.Side ||
                (this.Side != null &&
                    this.Side.Equals (input.Side))
            ) &&
            (
                this.OrderType == input.OrderType ||
                (this.OrderType != null &&
                    this.OrderType.Equals (input.OrderType))
            ) &&
            (
                this.Price == input.Price ||
                (this.Price != null &&
                    this.Price.Equals (input.Price))
            ) &&
            (
                this.TimeInForce == input.TimeInForce ||
                (this.TimeInForce != null &&
                    this.TimeInForce.Equals (input.TimeInForce))
            ) &&
            (
                this.OrderStatus == input.OrderStatus ||
                (this.OrderStatus != null &&
                    this.OrderStatus.Equals (input.OrderStatus))
            ) &&
            (
                this.LastExecTime == input.LastExecTime ||
                (this.LastExecTime != null &&
                    this.LastExecTime.Equals (input.LastExecTime))
            ) &&
            (
                this.LastExecPrice == input.LastExecPrice ||
                (this.LastExecPrice != null &&
                    this.LastExecPrice.Equals (input.LastExecPrice))
            ) &&
            (
                this.LeavesQty == input.LeavesQty ||
                (this.LeavesQty != null &&
                    this.LeavesQty.Equals (input.LeavesQty))
            ) &&
            (
                this.CumExecQty == input.CumExecQty ||
                (this.CumExecQty != null &&
                    this.CumExecQty.Equals (input.CumExecQty))
            ) &&
            (
                this.CumExecValue == input.CumExecValue ||
                (this.CumExecValue != null &&
                    this.CumExecValue.Equals (input.CumExecValue))
            ) &&
            (
                this.CumExecFee == input.CumExecFee ||
                (this.CumExecFee != null &&
                    this.CumExecFee.Equals (input.CumExecFee))
            ) &&
            (
                this.RejectReason == input.RejectReason ||
                (this.RejectReason != null &&
                    this.RejectReason.Equals (input.RejectReason))
            ) &&
            (
                this.OrderLinkId == input.OrderLinkId ||
                (this.OrderLinkId != null &&
                    this.OrderLinkId.Equals (input.OrderLinkId))
            ) &&
            (
                this.CreatedAt == input.CreatedAt ||
                (this.CreatedAt != null &&
                    this.CreatedAt.Equals (input.CreatedAt))
            ) &&
            (
                this.UpdatedAt == input.UpdatedAt ||
                (this.UpdatedAt != null &&
                    this.UpdatedAt.Equals (input.UpdatedAt))
            );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode () {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.OrderId != null)
                    hashCode = hashCode * 59 + this.OrderId.GetHashCode ();
                if (this.UserId != null)
                    hashCode = hashCode * 59 + this.UserId.GetHashCode ();
                if (this.Symbol != null)
                    hashCode = hashCode * 59 + this.Symbol.GetHashCode ();
                if (this.Side != null)
                    hashCode = hashCode * 59 + this.Side.GetHashCode ();
                if (this.OrderType != null)
                    hashCode = hashCode * 59 + this.OrderType.GetHashCode ();
                if (this.Price != null)
                    hashCode = hashCode * 59 + this.Price.GetHashCode ();
                if (this.TimeInForce != null)
                    hashCode = hashCode * 59 + this.TimeInForce.GetHashCode ();
                if (this.OrderStatus != null)
                    hashCode = hashCode * 59 + this.OrderStatus.GetHashCode ();
                if (this.LastExecTime != null)
                    hashCode = hashCode * 59 + this.LastExecTime.GetHashCode ();
                if (this.LastExecPrice != null)
                    hashCode = hashCode * 59 + this.LastExecPrice.GetHashCode ();
                if (this.LeavesQty != null)
                    hashCode = hashCode * 59 + this.LeavesQty.GetHashCode ();
                if (this.CumExecQty != null)
                    hashCode = hashCode * 59 + this.CumExecQty.GetHashCode ();
                if (this.CumExecValue != null)
                    hashCode = hashCode * 59 + this.CumExecValue.GetHashCode ();
                if (this.CumExecFee != null)
                    hashCode = hashCode * 59 + this.CumExecFee.GetHashCode ();
                if (this.RejectReason != null)
                    hashCode = hashCode * 59 + this.RejectReason.GetHashCode ();
                if (this.OrderLinkId != null)
                    hashCode = hashCode * 59 + this.OrderLinkId.GetHashCode ();
                if (this.CreatedAt != null)
                    hashCode = hashCode * 59 + this.CreatedAt.GetHashCode ();
                if (this.UpdatedAt != null)
                    hashCode = hashCode * 59 + this.UpdatedAt.GetHashCode ();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate (ValidationContext validationContext) {
            yield break;
        }
    }

}