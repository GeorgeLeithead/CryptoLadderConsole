using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InternetWideWorld.CryptoLadder.Shared.Model
{
    /// <summary>
    /// Place new order response
    /// </summary>
    [DataContract]
    public partial class OrderRes : IEquatable<OrderRes>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRes" /> class.
        /// </summary>
        public OrderRes()
        { }

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
        public OrderRes(string orderId = default, decimal? userId = default, string symbol = default, string side = default, string orderType = default, double? price = default, int qty = default, string timeInForce = default, string orderStatus = default, double? lastExecTime = default, double? lastExecPrice = default, decimal? leavesQty = default, decimal? cumExecQty = default, decimal? cumExecValue = default, double? cumExecFee = default, string rejectReason = default, string orderLinkId = default, string createdAt = default, string updatedAt = default)
        {
            OrderId = orderId;
            UserId = userId;
            Symbol = symbol;
            Side = side;
            OrderType = orderType;
            Price = price;
            Qty = qty;
            TimeInForce = timeInForce;
            OrderStatus = orderStatus;
            LastExecTime = lastExecTime;
            LastExecPrice = lastExecPrice;
            LeavesQty = leavesQty;
            CumExecQty = cumExecQty;
            CumExecValue = cumExecValue;
            CumExecFee = cumExecFee;
            RejectReason = rejectReason;
            OrderLinkId = orderLinkId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// Gets or Sets OrderId
        /// </summary>
        [JsonPropertyName("order_id")]
        [DataMember(Name = "order_id", EmitDefaultValue = false)]
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or Sets UserId
        /// </summary>
        [JsonPropertyName("user_id")]
        [DataMember(Name = "user_id", EmitDefaultValue = false)]
        public decimal? UserId { get; set; }

        /// <summary>
        /// Gets or Sets Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        [DataMember(Name = "symbol", EmitDefaultValue = false)]
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or Sets Side
        /// </summary>
        [JsonPropertyName("side")]
        [DataMember(Name = "side", EmitDefaultValue = false)]
        public string Side { get; set; }

        /// <summary>
        /// Gets or Sets OrderType
        /// </summary>
        [JsonPropertyName("order_type")]
        [DataMember(Name = "order_type", EmitDefaultValue = false)]
        public string OrderType { get; set; }

        /// <summary>
        /// Gets or Sets Price
        /// </summary>
        [JsonPropertyName("price")]
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public double? Price { get; set; }

        /// <summary>
        /// Gets or Sets Qty
        /// </summary>
        [JsonPropertyName("qty")]
        [DataMember(Name = "qty", EmitDefaultValue = false)]
        public int Qty { get; set; }

        /// <summary>
        /// Gets or Sets TimeInForce
        /// </summary>
        [JsonPropertyName("time_in_force")]
        [DataMember(Name = "time_in_force", EmitDefaultValue = false)]
        public string TimeInForce { get; set; }

        /// <summary>
        /// Gets or Sets OrderStatus
        /// </summary>
        [JsonPropertyName("order_status")]
        [DataMember(Name = "order_status", EmitDefaultValue = false)]
        public string OrderStatus { get; set; }

        /// <summary>
        /// Gets or Sets LastExecTime
        /// </summary>
        [JsonPropertyName("last_exec_time")]
        [DataMember(Name = "last_exec_time", EmitDefaultValue = false)]
        public double? LastExecTime { get; set; }

        /// <summary>
        /// Gets or Sets LastExecPrice
        /// </summary>
        [JsonPropertyName("last_exec_price")]
        [DataMember(Name = "last_exec_price", EmitDefaultValue = false)]
        public double? LastExecPrice { get; set; }

        /// <summary>
        /// Gets or Sets LeavesQty
        /// </summary>
        [JsonPropertyName("leaves_qty")]
        [DataMember(Name = "leaves_qty", EmitDefaultValue = false)]
        public decimal? LeavesQty { get; set; }

        /// <summary>
        /// Gets or Sets CumExecQty
        /// </summary>
        [JsonPropertyName("cum_exec_qty")]
        [DataMember(Name = "cum_exec_qty", EmitDefaultValue = false)]
        public decimal? CumExecQty { get; set; }

        /// <summary>
        /// Gets or Sets CumExecValue
        /// </summary>
        [JsonPropertyName("cum_exec_value")]
        [DataMember(Name = "cum_exec_value", EmitDefaultValue = false)]
        public decimal? CumExecValue { get; set; }

        /// <summary>
        /// Gets or Sets CumExecFee
        /// </summary>
        [JsonPropertyName("cum_exec_fee")]
        [DataMember(Name = "cum_exec_fee", EmitDefaultValue = false)]
        public double? CumExecFee { get; set; }

        /// <summary>
        /// Gets or Sets RejectReason
        /// </summary>
        [JsonPropertyName("reject_reason")]
        [DataMember(Name = "reject_reason", EmitDefaultValue = false)]
        public string RejectReason { get; set; }

        /// <summary>
        /// Gets or Sets OrderLinkId
        /// </summary>
        [JsonPropertyName("order_link_id")]
        [DataMember(Name = "order_link_id", EmitDefaultValue = false)]
        public string OrderLinkId { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [JsonPropertyName("created_at")]
        [DataMember(Name = "created_at", EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        [JsonPropertyName("updated_at")]
        [DataMember(Name = "updated_at", EmitDefaultValue = false)]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class OrderRes {\n");
            sb.Append("  OrderId: ").Append(OrderId).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  Symbol: ").Append(Symbol).Append("\n");
            sb.Append("  Side: ").Append(Side).Append("\n");
            sb.Append("  OrderType: ").Append(OrderType).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  Qty: ").Append(Qty).Append("\n");
            sb.Append("  TimeInForce: ").Append(TimeInForce).Append("\n");
            sb.Append("  OrderStatus: ").Append(OrderStatus).Append("\n");
            sb.Append("  LastExecTime: ").Append(LastExecTime).Append("\n");
            sb.Append("  LastExecPrice: ").Append(LastExecPrice).Append("\n");
            sb.Append("  LeavesQty: ").Append(LeavesQty).Append("\n");
            sb.Append("  CumExecQty: ").Append(CumExecQty).Append("\n");
            sb.Append("  CumExecValue: ").Append(CumExecValue).Append("\n");
            sb.Append("  CumExecFee: ").Append(CumExecFee).Append("\n");
            sb.Append("  RejectReason: ").Append(RejectReason).Append("\n");
            sb.Append("  OrderLinkId: ").Append(OrderLinkId).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
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
        public override bool Equals(object input)
        {
            return Equals(input as OrderRes);
        }

        /// <summary>
        /// Returns true if OrderRes instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderRes to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderRes input)
        {
            if (input == null)
            {
                return false;
            }

            return (
                OrderId == input.OrderId ||
                (OrderId != null &&
                    OrderId.Equals(input.OrderId))
            ) &&
            (
                UserId == input.UserId ||
                (UserId != null &&
                    UserId.Equals(input.UserId))
            ) &&
            (
                Symbol == input.Symbol ||
                (Symbol != null &&
                    Symbol.Equals(input.Symbol))
            ) &&
            (
                Side == input.Side ||
                (Side != null &&
                    Side.Equals(input.Side))
            ) &&
            (
                OrderType == input.OrderType ||
                (OrderType != null &&
                    OrderType.Equals(input.OrderType))
            ) &&
            (
                Price == input.Price ||
                (Price != null &&
                    Price.Equals(input.Price))
            ) &&
            (
                TimeInForce == input.TimeInForce ||
                (TimeInForce != null &&
                    TimeInForce.Equals(input.TimeInForce))
            ) &&
            (
                OrderStatus == input.OrderStatus ||
                (OrderStatus != null &&
                    OrderStatus.Equals(input.OrderStatus))
            ) &&
            (
                LastExecTime == input.LastExecTime ||
                (LastExecTime != null &&
                    LastExecTime.Equals(input.LastExecTime))
            ) &&
            (
                LastExecPrice == input.LastExecPrice ||
                (LastExecPrice != null &&
                    LastExecPrice.Equals(input.LastExecPrice))
            ) &&
            (
                LeavesQty == input.LeavesQty ||
                (LeavesQty != null &&
                    LeavesQty.Equals(input.LeavesQty))
            ) &&
            (
                CumExecQty == input.CumExecQty ||
                (CumExecQty != null &&
                    CumExecQty.Equals(input.CumExecQty))
            ) &&
            (
                CumExecValue == input.CumExecValue ||
                (CumExecValue != null &&
                    CumExecValue.Equals(input.CumExecValue))
            ) &&
            (
                CumExecFee == input.CumExecFee ||
                (CumExecFee != null &&
                    CumExecFee.Equals(input.CumExecFee))
            ) &&
            (
                RejectReason == input.RejectReason ||
                (RejectReason != null &&
                    RejectReason.Equals(input.RejectReason))
            ) &&
            (
                OrderLinkId == input.OrderLinkId ||
                (OrderLinkId != null &&
                    OrderLinkId.Equals(input.OrderLinkId))
            ) &&
            (
                CreatedAt == input.CreatedAt ||
                (CreatedAt != null &&
                    CreatedAt.Equals(input.CreatedAt))
            ) &&
            (
                UpdatedAt == input.UpdatedAt ||
                (UpdatedAt != null &&
                    UpdatedAt.Equals(input.UpdatedAt))
            );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (OrderId != null)
                {
                    hashCode = hashCode * 59 + OrderId.GetHashCode();
                }

                if (UserId != null)
                {
                    hashCode = hashCode * 59 + UserId.GetHashCode();
                }

                if (Symbol != null)
                {
                    hashCode = hashCode * 59 + Symbol.GetHashCode();
                }

                if (Side != null)
                {
                    hashCode = hashCode * 59 + Side.GetHashCode();
                }

                if (OrderType != null)
                {
                    hashCode = hashCode * 59 + OrderType.GetHashCode();
                }

                if (Price != null)
                {
                    hashCode = hashCode * 59 + Price.GetHashCode();
                }

                if (TimeInForce != null)
                {
                    hashCode = hashCode * 59 + TimeInForce.GetHashCode();
                }

                if (OrderStatus != null)
                {
                    hashCode = hashCode * 59 + OrderStatus.GetHashCode();
                }

                if (LastExecTime != null)
                {
                    hashCode = hashCode * 59 + LastExecTime.GetHashCode();
                }

                if (LastExecPrice != null)
                {
                    hashCode = hashCode * 59 + LastExecPrice.GetHashCode();
                }

                if (LeavesQty != null)
                {
                    hashCode = hashCode * 59 + LeavesQty.GetHashCode();
                }

                if (CumExecQty != null)
                {
                    hashCode = hashCode * 59 + CumExecQty.GetHashCode();
                }

                if (CumExecValue != null)
                {
                    hashCode = hashCode * 59 + CumExecValue.GetHashCode();
                }

                if (CumExecFee != null)
                {
                    hashCode = hashCode * 59 + CumExecFee.GetHashCode();
                }

                if (RejectReason != null)
                {
                    hashCode = hashCode * 59 + RejectReason.GetHashCode();
                }

                if (OrderLinkId != null)
                {
                    hashCode = hashCode * 59 + OrderLinkId.GetHashCode();
                }

                if (CreatedAt != null)
                {
                    hashCode = hashCode * 59 + CreatedAt.GetHashCode();
                }

                if (UpdatedAt != null)
                {
                    hashCode = hashCode * 59 + UpdatedAt.GetHashCode();
                }

                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}